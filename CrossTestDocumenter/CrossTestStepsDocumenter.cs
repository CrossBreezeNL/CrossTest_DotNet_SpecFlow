using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using CrossBreeze.CrossDoc.CustomAttributes;
using TechTalk.SpecFlow;

namespace CrossTestDocumenter
{
    public class CrossTestStepsDocumenter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public CrossTestStepsDocumenter() { }

        /// <summary>
        /// Create the specflow xml file for CrossTest, to generate the docs from.
        /// </summary>
        /// <param name="crossTest"></param>
        /// <param name="outputFileLocation"></param>
        public void CreateSpecflowDocumentation(Assembly crossTest, string outputFileLocation)
        {
            using (StreamWriter sw = new StreamWriter(outputFileLocation, false))
            {
                DocumentationHelper.WriteToOutput("<CrossTestSpec>", 0, sw);
                //Loop through types and look for types containing step definitions
                foreach (Type t in crossTest.DefinedTypes)
                {
                    Boolean includeClass = false;
                    //If Type contains BindingAttribute, include in output and scan methods
                    foreach (CustomAttributeData cad in t.CustomAttributes)
                    {
                        if (cad.AttributeType.Name.Equals("BindingAttribute"))
                        {
                            includeClass = true;
                        }

                    }
                    if (includeClass)
                    {
                        // Create a list for the new types referenced in the current type.
                        List<Type> foundLocalTypes = new List<Type>();

                        DocumentationHelper.WriteToOutput("<Class name=\"" + t.Name + "\">", 1, sw);
                        DocumentationHelper.WriteToOutput("<Steps>", 2, sw);

                        // Scan methods, if Given, When or Then Attribute is found, output the attribute value and method parameters
                        // Each step is marked with at least a Given, When or Then CustomAttribute. They all extend the StepDefinitionBaseAttribute class.
                        foreach (MethodInfo mi in t.GetMethods().Where(m => m.IsPublic && m.GetCustomAttributes<StepDefinitionBaseAttribute>().Count() > 0))
                        {
                            String methodDescription = "";
                            String title = mi.Name;
                            // Check for custom XDocAttribute attribute
                            // The statement below should get the appropriate custom attribute but it fails unless referring to the exact dll that is used in this project.
                            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/2ff0db45-c21c-4075-ab1d-0c3e63aaa2d7/getcustomattributes-for-a-specific-type-always-returns-null?forum=csharpgeneral
                            // https://bytes.com/topic/net/answers/652618-type-getcustomerattributes-not-working-expected
                            XDocAttribute stepDocAttribute = mi.GetCustomAttribute<XDocAttribute>();

                            //If found, extract description and argumentDescriptions if given
                            if (stepDocAttribute != null)
                            {
                                methodDescription = " description=\"" + stepDocAttribute.Description + "\"";
                                if (stepDocAttribute.Title != "")
                                {
                                    title = stepDocAttribute.Title;
                                }
                            }
                            DocumentationHelper.WriteToOutput("<Step id=\"" + mi.Name + "\" title=\"" + title + "\"" + methodDescription + ">", 3, sw);
                            DocumentationHelper.WriteToOutput("<Arguments>", 4, sw);

                            foreach (ParameterInfo pi in mi.GetParameters())
                            {
                                string paramDescription = "";
                                string paramTitle = pi.Name;
                                XDocAttribute paramDocAttribute = (XDocAttribute)pi.GetCustomAttribute(typeof(XDocAttribute));
                                if (paramDocAttribute != null)
                                {
                                    paramDescription = " description=\"" + paramDocAttribute.Description.Replace("|", "\\|") + "\"";
                                    if (paramDocAttribute.Title != "")
                                    {
                                        paramTitle = paramDocAttribute.Title;
                                    }
                                }
                                DocumentationHelper.WriteToOutput(string.Format("<Argument name=\"{0}\" title=\"{1}\" dataType=\"{2}\" isLocalType=\"{3}\"{4}/>", pi.Name, paramTitle, pi.ParameterType.Name, pi.ParameterType.Module.Name.StartsWith(CrossTestDocumenter.CROSSTEST_NAMESPACE), paramDescription), 5, sw);

                                // If the referenced type is declared in the same module and it isn't exported yet, add it to the list.
                                if (pi.ParameterType.Module.Name.StartsWith(CrossTestDocumenter.CROSSTEST_NAMESPACE) && !foundLocalTypes.Contains(pi.ParameterType))
                                    foundLocalTypes.Add(pi.ParameterType);
                            }
                            DocumentationHelper.WriteToOutput("</Arguments>", 4, sw);
                            //Sentences
                            DocumentationHelper.WriteToOutput("<Sentences>", 4, sw);
                            // Get all CustomAttribeData from the SpecFlow StepDefinitionBaseAttribute's
                            foreach (CustomAttributeData cad in mi.GetCustomAttributesData().Where(ca => ca.AttributeType.IsSubclassOf(typeof(StepDefinitionBaseAttribute))))
                            {
                                String culture = "en";
                                IEnumerable<CustomAttributeNamedArgument> cultureAttrColl = cad.NamedArguments.Where(c => c.MemberName == "Culture");
                                if (cultureAttrColl.Count() != 0)
                                {
                                    culture = (string)cultureAttrColl.First().TypedValue.Value;
                                }
                                DocumentationHelper.WriteToOutput(string.Format("<Sentence type=\"{0}\" text=\"{1}\" culture=\"{2}\" />", cad.AttributeType.Name.Replace("Attribute", ""), DocumentationHelper.EntityEncode(cad.ConstructorArguments[0].ToString().Replace("\"", "")).Replace("|", "\\|"), culture), 5, sw);
                            }
                            DocumentationHelper.WriteToOutput("</Sentences>", 4, sw);
                            //Examples
                            DocumentationHelper.WriteToOutput("<Examples>", 4, sw);
                            foreach (XDocExampleAttribute xea in (IEnumerable<XDocExampleAttribute>)mi.GetCustomAttributes(typeof(XDocExampleAttribute)))
                            {
                                if (xea.Description != null)
                                    DocumentationHelper.WriteToOutput(string.Format("<Example description=\"{0}\">{1}</Example>", DocumentationHelper.EntityEncode(xea.Description), DocumentationHelper.EntityEncode(xea.Example)), 5, sw);
                                else
                                    DocumentationHelper.WriteToOutput(string.Format("<Example>{0}</Example>", DocumentationHelper.EntityEncode(xea.Example)), 5, sw);
                            }
                            DocumentationHelper.WriteToOutput("</Examples>", 4, sw);
                            //Close step
                            DocumentationHelper.WriteToOutput("</Step>", 3, sw);
                        }

                        DocumentationHelper.WriteToOutput("</Steps>", 2, sw);

                        // If there are local types found, export them as well.
                        if (foundLocalTypes.Count > 0)
                        {
                            DocumentationHelper.WriteToOutput("<Types>", 2, sw);

                            foreach (Type localType in foundLocalTypes)
                            {
                                DocumentationHelper.WriteToOutput(string.Format("<Type{0}>", DocumentationHelper.GetXDocTitleAndDescription(localType.GetCustomAttribute<XDocAttribute>())), 3, sw);
                                DocumentationHelper.WriteToOutput("<Examples>", 4, sw);
                                foreach (XDocExampleAttribute xea in (IEnumerable<XDocExampleAttribute>)localType.GetCustomAttributes(typeof(XDocExampleAttribute)))
                                {
                                    if (xea.Description != null)
                                        DocumentationHelper.WriteToOutput(string.Format("<Example description=\"{0}\">{1}</Example>", DocumentationHelper.EntityEncode(xea.Description), DocumentationHelper.EntityEncode(xea.Example)), 5, sw);
                                    else
                                        DocumentationHelper.WriteToOutput(string.Format("<Example>{0}</Example>", DocumentationHelper.EntityEncode(xea.Example)), 5, sw);
                                }
                                DocumentationHelper.WriteToOutput("</Examples>", 4, sw);
                                DocumentationHelper.WriteToOutput("</Type>", 3, sw);
                            }

                            DocumentationHelper.WriteToOutput("</Types>", 2, sw);
                        }

                        DocumentationHelper.WriteToOutput("</Class>", 1, sw);
                    }
                }
                DocumentationHelper.WriteToOutput("</CrossTestSpec>", 0, sw);
            }
        }
    }
}
