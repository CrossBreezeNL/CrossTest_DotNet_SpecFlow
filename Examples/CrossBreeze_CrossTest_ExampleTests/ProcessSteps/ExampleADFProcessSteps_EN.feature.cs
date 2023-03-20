﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CrossBreeze.CrossTest.ExampleTests.ProcessSteps
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RunExampleADFProcesENFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = new string[] {
                "ADF"};
        
#line 1 "ExampleADFProcessSteps_EN.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en"), "ProcessSteps", "Run Example ADF proces (EN)", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Run Example ADF proces (EN)")))
            {
                global::CrossBreeze.CrossTest.ExampleTests.ProcessSteps.RunExampleADFProcesENFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
#line 6
 testRunner.Given("the ExampleMsSqlServer database server is used", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.And("the Tempdb database is used", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
 testRunner.When("I execute the following SQL query:", "IF (object_ID(\'testTable\') IS NOT NULL)\r\nBEGIN\r\nDROP TABLE testTable\r\nEND\r\n\r\nCREA" +
                    "TE TABLE testTable (id INT, description VARCHAR(50))\r\n\r\ninsert into  [tempdb].[d" +
                    "bo].[testTable] values (1, \'FirstRow\')", ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Run ADF proces")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Run Example ADF proces (EN)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ADF")]
        public void RunADFProces()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run ADF proces", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 21
 testRunner.When("the CrossTestPipeline ADF process in the ExampleAdfPipeline project is being exec" +
                        "uted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 22
 testRunner.And("I retrieve the contents of the [dbo].[testTable] table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table45 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "description"});
                table45.AddRow(new string[] {
                            "1",
                            "\'FirstRow\'"});
#line 23
 testRunner.Then("I expect the following results:", ((string)(null)), table45, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Run typed ADF proces")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Run Example ADF proces (EN)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ADF")]
        public void RunTypedADFProces()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run typed ADF proces", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 29
 testRunner.When("the CrossTestPipelineWithParameters adfTemplate ADF process in the ExampleAdfPipe" +
                        "line project is being executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.And("I retrieve the contents of the [dbo].[testTable] table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table46 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "description"});
                table46.AddRow(new string[] {
                            "1",
                            "\'FirstRow\'"});
#line 31
 testRunner.Then("I expect the following results:", ((string)(null)), table46, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Run ADF proces with parameters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Run Example ADF proces (EN)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ADF")]
        public void RunADFProcesWithParameters()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run ADF proces with parameters", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table47 = new TechTalk.SpecFlow.Table(new string[] {
                            "Parameter",
                            "Value"});
                table47.AddRow(new string[] {
                            "baseUrl",
                            "https://x-test.nl/"});
                table47.AddRow(new string[] {
                            "uri",
                            "DotNet"});
#line 36
 testRunner.When("the CrossTestPipelineWithParameters ADF process in the ExampleAdfPipeline project" +
                        " is being executed with the following parameter:", ((string)(null)), table47, "When ");
#line hidden
#line 40
 testRunner.And("I retrieve the contents of the [dbo].[testTable] table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table48 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "description"});
                table48.AddRow(new string[] {
                            "1",
                            "\'FirstRow\'"});
#line 41
 testRunner.Then("I expect the following results:", ((string)(null)), table48, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Run typed ADF proces with parameters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Run Example ADF proces (EN)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ADF")]
        public void RunTypedADFProcesWithParameters()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run typed ADF proces with parameters", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 45
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table49 = new TechTalk.SpecFlow.Table(new string[] {
                            "Parameter",
                            "Value"});
                table49.AddRow(new string[] {
                            "uri",
                            "Java"});
#line 46
 testRunner.When("the CrossTestPipelineWithParameters adfTemplate ADF process in the ExampleAdfPipe" +
                        "line project is being executed with the following parameter:", ((string)(null)), table49, "When ");
#line hidden
#line 49
 testRunner.And("I retrieve the contents of the [dbo].[testTable] table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table50 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "description"});
                table50.AddRow(new string[] {
                            "1",
                            "\'FirstRow\'"});
#line 50
 testRunner.Then("I expect the following results:", ((string)(null)), table50, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
