using CrossBreeze.CrossTest.SpecFlow.Helpers;
using System.Data;

namespace CrossBreeze.CrossTest.SpecFlow.Result.Context
{
    public class ResultContext
    {
        public DataTable ResultTable;

        public void SetResultTable(DataTable resultTable)
        {
            this.ResultTable = resultTable;
        }

        public static ResultContext GetResultContext()
        {
            if (!ScenarioContextHelper.HasScenarioContextObject(ScenarioContextHelper.ScenarioObjectType.Result))
                ScenarioContextHelper.SetScenarioContextObject(ScenarioContextHelper.ScenarioObjectType.Result, new ResultContext());
            return ScenarioContextHelper.GetScenarioContextObject(ScenarioContextHelper.ScenarioObjectType.Result) as ResultContext;
        }
    }
}
