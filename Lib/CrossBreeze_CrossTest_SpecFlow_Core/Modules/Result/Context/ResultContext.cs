using CrossBreeze.CrossTest.SpecFlow.Helpers;
using System.Data;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Result.Context
{
    public class ResultContext
    {
        public DataTable ResultTable;

        public void SetResultTable(DataTable resultTable)
        {
            this.ResultTable = resultTable;
        }

        public static ResultContext GetResultContext(ScenarioContext scenarioContext)
        {
            if (!ScenarioContextHelper.HasScenarioContextObject(scenarioContext, ScenarioContextHelper.ScenarioObjectType.Result))
                ScenarioContextHelper.SetScenarioContextObject(scenarioContext, ScenarioContextHelper.ScenarioObjectType.Result, new ResultContext());
            return ScenarioContextHelper.GetScenarioContextObject(scenarioContext, ScenarioContextHelper.ScenarioObjectType.Result) as ResultContext;
        }
    }
}
