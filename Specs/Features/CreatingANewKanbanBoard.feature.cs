// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.5.0.0
//      Runtime Version:4.0.30319.208
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Creating a new Kanban board")]
    public partial class CreatingANewKanbanBoardFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreatingANewKanbanBoard.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Creating a new Kanban board", "In order to show off my great kanban board and get some insightful feedback\r\nAs a" +
                    " logged-in user\r\nI want to be able to create information about a new Kanban boar" +
                    "d", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            this.FeatureBackground();
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "User",
                        "TimesFavorited",
                        "Posted",
                        "Thumbnail"});
            table1.AddRow(new string[] {
                        "Demo 1",
                        "Marcus",
                        "100",
                        "2010-01-01",
                        "/thumbnails/demo1_thumb.jpg"});
            table1.AddRow(new string[] {
                        "Kanban 1",
                        "David",
                        "1000",
                        "2010-04-01",
                        "/thumbnails/kanban1_thumb.jpg"});
            table1.AddRow(new string[] {
                        "Demo 2",
                        "Joakim",
                        "300",
                        "2010-06-01",
                        "/thumbnails/demo2_thumb.jpg"});
            table1.AddRow(new string[] {
                        "My new board",
                        "Christophe",
                        "50",
                        "2011-01-01",
                        "/thumbnails/mynewboard_thumb.jpg"});
#line 7
  testRunner.Given("the following Kanbanboards", ((string)(null)), table1);
#line 13
  testRunner.And("I am logged in on the site as Marcus");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a Kanban board with all the required information")]
        public virtual void CreateAKanbanBoardWithAllTheRequiredInformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a Kanban board with all the required information", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.When("I navigate to to the create new kanbanboard page");
#line 17
 testRunner.Then("I should be on the Create page");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Title",
                        "KanbanBoard 1"});
            table2.AddRow(new string[] {
                        "Description",
                        "This is a board that we\'ve put together in my last project"});
            table2.AddRow(new string[] {
                        "Tags",
                        "Software, Developement, Swedish"});
            table2.AddRow(new string[] {
                        "BoardImage",
                        "mycoolboard.jpg"});
#line 18
 testRunner.When("I submit a board with the following information", ((string)(null)), table2);
#line 24
 testRunner.Then("I should be redirected the MyBoards page");
#line 25
 testRunner.When("I am redirected to the MyBoards page");
#line 26
 testRunner.Then("I should be on the MyBoards page");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "User"});
            table3.AddRow(new string[] {
                        "Demo 1",
                        "Marcus"});
            table3.AddRow(new string[] {
                        "KanbanBoard 1",
                        "Marcus"});
#line 27
  testRunner.And("the following boards should be listed as my boards:", ((string)(null)), table3);
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
