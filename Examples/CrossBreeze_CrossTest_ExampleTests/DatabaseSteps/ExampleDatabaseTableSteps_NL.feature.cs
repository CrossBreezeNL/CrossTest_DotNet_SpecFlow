﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CrossBreeze.CrossTest.ExampleTests.DatabaseSteps
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DatabaseTableTestStepsNLFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ExampleDatabaseTableSteps_NL.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("nl"), "Database table test steps (NL)", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Database table test steps (NL)")))
            {
                global::CrossBreeze.CrossTest.ExampleTests.DatabaseSteps.DatabaseTableTestStepsNLFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
 testRunner.Given("de ExampleMsSqlServer database server wordt gebruikt", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeven ");
#line 6
 testRunner.And("de ExampleDatabase database wordt gebruikt", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "En ");
#line hidden
#line 7
 testRunner.When("ik de volgende SQL query uitvoer:", "CREATE TABLE [#testTable] (\r\n\t[Id] int,\r\n\t[Description] varchar(50),\r\n\t[StageDate" +
                    "Time] datetime2(2)\r\n)", ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Laad data naar tabel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Database table test steps (NL)")]
        public virtual void LaadDataNaarTabel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Laad data naar tabel", null, ((string[])(null)));
#line 16
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Description"});
            table1.AddRow(new string[] {
                        "1",
                        "\'FirstRow\'"});
            table1.AddRow(new string[] {
                        "2",
                        "\'SecondRow\'"});
#line 17
 testRunner.Given("de tabel [dbo].[#testTable] met de volgende data geladen wordt:", ((string)(null)), table1, "Gegeven ");
#line 21
 testRunner.When("ik de inhoud van de tabel [dbo].[#testTable] ophaal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Description"});
            table2.AddRow(new string[] {
                        "1",
                        "\'FirstRow\'"});
            table2.AddRow(new string[] {
                        "2",
                        "\'SecondRow\'"});
#line 22
 testRunner.Then("verwacht ik het volgende resultaat:", ((string)(null)), table2, "Dan ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Laad data naar template tabel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Database table test steps (NL)")]
        public virtual void LaadDataNaarTemplateTabel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Laad data naar template tabel", null, ((string[])(null)));
#line 27
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Description"});
            table3.AddRow(new string[] {
                        "1",
                        "\'FirstRow\'"});
            table3.AddRow(new string[] {
                        "2",
                        "\'SecondRow\'"});
#line 28
 testRunner.Given("de staging-storage tabel [dbo].[#testTable] met de volgende data geladen wordt:", ((string)(null)), table3, "Gegeven ");
#line 32
 testRunner.When("ik de inhoud van de tabel [dbo].[#testTable] ophaal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Description",
                        "StageDateTime"});
            table4.AddRow(new string[] {
                        "1",
                        "\'FirstRow\'",
                        "2000-01-01 00:00:00.00"});
            table4.AddRow(new string[] {
                        "2",
                        "\'SecondRow\'",
                        "2000-01-01 00:00:00.00"});
#line 33
 testRunner.Then("verwacht ik het volgende resultaat:", ((string)(null)), table4, "Dan ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Maak de table leeg")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Database table test steps (NL)")]
        public virtual void MaakDeTableLeeg()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Maak de table leeg", null, ((string[])(null)));
#line 38
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 39
 testRunner.Given("dat de tabel [dbo].[#testTable] leeg is", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeven ");
#line 40
 testRunner.When("ik de inhoud van de tabel [dbo].[#testTable] ophaal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Description",
                        "StageDateTime"});
#line 41
 testRunner.Then("verwacht ik het volgende resultaat:", ((string)(null)), table5, "Dan ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

