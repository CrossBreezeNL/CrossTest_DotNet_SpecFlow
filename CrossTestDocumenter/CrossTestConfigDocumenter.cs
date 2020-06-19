using System;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossTestDocumenter
{

    public class CrossTestConfigDocumenter
    {
        // The name of the root element.
        private static readonly string ROOT_NODE_ELEMENT_NAME = "ConfigDefinition";

        // List of types which are exported. This is to track exported types so we export them once.
        private List<Type> _exportedTypes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configAssembly"></param>
        /// <param name="outputFileLocation"></param>
        public CrossTestConfigDocumenter()
        {
            // Initialize the type array.
            _exportedTypes = new List<Type>();
        }

        /// <summary>
        /// Create the config xml file for CrossTest, to generate the docs from.
        /// </summary>
        /// <param name="configAssembly"></param>
        /// <param name="outputFileLocation"></param>
        public void CreateConfigDocumentation(Type configType, string outputFileLocation)
        {
            // Create a StreamWriter for the output file.
            using (StreamWriter sw = new StreamWriter(outputFileLocation, false))
            {
                // Write the opening tag.
                DocumentationHelper.WriteToOutput(string.Format("<{0}>", ROOT_NODE_ELEMENT_NAME), 0, sw);

                // Add the config section for the configType.
                AddConfigTestSection(configType, sw, 1);

                // Write the closing tag.
                DocumentationHelper.WriteToOutput(string.Format("</{0}>", ROOT_NODE_ELEMENT_NAME), 0, sw);
            }
        }

        /// <summary>
        /// Add a config test section based on the type.
        /// </summary>
        /// <param name="configType"></param>
        /// <param name="sw"></param>
        /// <param name="indent"></param>
        private void AddConfigTestSection(Type configType, StreamWriter sw, int indent)
        {

            // Enum
            if (configType.IsEnum)
            {
                // Write the opening tag of the config element type.
                DocumentationHelper.WriteToOutput(string.Format("<ConfigEnumType name=\"{0}\"{1}>", configType.Name, DocumentationHelper.GetXDocTitleAndDescription(configType.GetCustomAttribute<XDocAttribute>())), indent, sw);

                // Loop through all public methods in the current type and search for the configuration attributes.
                foreach (FieldInfo enumFieldInfo in configType.GetFields().Where(f => f.IsPublic && f.IsStatic))
                {
                    DocumentationHelper.WriteToOutput(string.Format("<EnumValue name=\"{0}\"{1} />", enumFieldInfo.Name, DocumentationHelper.GetXDocTitleAndDescription(enumFieldInfo.GetCustomAttribute<XDocAttribute>())), indent + 1, sw);
                }

                // Write the closing tag of the config element type.
                DocumentationHelper.WriteToOutput("</ConfigEnumType>", indent, sw);
            }

            // Any other, probably Class.
            else
            {
                // Write the opening tag of the config element type.
                DocumentationHelper.WriteToOutput(string.Format("<ConfigElementType name=\"{0}\"{1}>", configType.Name, DocumentationHelper.GetXDocTitleAndDescription(configType.GetCustomAttribute<XDocAttribute>())), indent, sw);

                // Add the current config type to the list of types which are exported.
                _exportedTypes.Add(configType);

                // Create a list for the new types referenced in the current type.
                List<Type> foundNewTypes = new List<Type>();

                // Loop through all public methods in the current type and search for the configuration attributes.
                foreach (PropertyInfo fi in configType.GetProperties())
                {
                    // The ConfigurationPropertyAttribute is the custom attribute which specifies the name of the config attribute.
                    ConfigurationPropertyAttribute cpa = fi.GetCustomAttribute<ConfigurationPropertyAttribute>();

                    // If the configuration property attribute is found, store the information in the xml file.
                    if (cpa != null)
                    {
                        // The ConfigurationCollectionAttribute is the custom attribute which specifies the collection type and element name.
                        ConfigurationCollectionAttribute cca = fi.GetCustomAttribute<ConfigurationCollectionAttribute>();

                        // If the collection attribute is set, the method returns a collection, otherwise a single element.
                        if (cca != null)
                        {
                            if (!fi.PropertyType.IsSubclassOf(typeof(ConfigurationElementCollection)))
                                throw new Exception(string.Format("The property '{0}' has a collection annotation but is not a subclass of ConfigurationElementCollection", fi.Name));

                            // The collection item is stored in the property 'Item' of the collection.
                            PropertyInfo itemPropertyInfo = fi.PropertyType.GetProperty("Item");

                            if (itemPropertyInfo == null)
                                throw new Exception(string.Format("The property '{0}' has a collection annotation but it's missing the item property", fi.Name));

                            // Write the collection node to the out.
                            DocumentationHelper.WriteToOutput(string.Format("<ConfigCollection name=\"{0}\" itemName=\"{1}\" itemType=\"{2}\"{3} />", cpa.Name, cca.AddItemName, itemPropertyInfo.PropertyType.Name, DocumentationHelper.GetXDocTitleAndDescription(fi.GetCustomAttribute<XDocAttribute>())), indent + 1, sw);

                            // If the referenced type is declared in the same module and it isn't exported yet, add it to the list.
                            if (itemPropertyInfo.PropertyType.Module.Name.StartsWith(CrossTestDocumenter.CROSSTEST_NAMESPACE) && !_exportedTypes.Contains(itemPropertyInfo.PropertyType) && !foundNewTypes.Contains(itemPropertyInfo.PropertyType))
                                foundNewTypes.Add(itemPropertyInfo.PropertyType);
                        }
                        else
                        {
                            string nodeName;
                            if (fi.PropertyType.Module.Name.StartsWith(CrossTestDocumenter.CROSSTEST_NAMESPACE))
                            {

                                if (fi.PropertyType.IsEnum)
                                {
                                    nodeName = "Enum";
                                }

                                else
                                {
                                    nodeName = "Element";
                                }

                                // If the referenced type is declared in the same module and it isn't exported yet, add it to the list.
                                if (fi.PropertyType.Module.Name.StartsWith(CrossTestDocumenter.CROSSTEST_NAMESPACE) && !_exportedTypes.Contains(fi.PropertyType) && !foundNewTypes.Contains(fi.PropertyType))
                                    foundNewTypes.Add(fi.PropertyType);
                            }
                            else
                            {
                                nodeName = "Attribute";
                            }

                            // Add the ConfigElement element to the XML.
                            DocumentationHelper.WriteToOutput(string.Format("<Config{0} name=\"{1}\" type=\"{2}\"{3} />", nodeName, cpa.Name, fi.PropertyType.Name, DocumentationHelper.GetXDocTitleAndDescription(fi.GetCustomAttribute<XDocAttribute>())), indent + 1, sw);

                        }
                    }
                }

                // Write the closing tag of the config element type.
                DocumentationHelper.WriteToOutput("</ConfigElementType>", indent, sw);

                // Loop through the new found types and export them.
                foreach (Type newFoundType in foundNewTypes)
                {
                    AddConfigTestSection(newFoundType, sw, indent);
                }
            }

        }

    }
}
