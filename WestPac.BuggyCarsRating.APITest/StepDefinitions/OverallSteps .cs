using Newtonsoft.Json;
using WestPac.BuggyCarsRating.APITest.Constants;
using WestPac.BuggyCarsRating.APITest.Models;
using WestPac.BuggyCarsRating.UITest.Services;

namespace WestPac.BuggyCarsRating.APITest.StepDefinitions
{
    [Binding]
    public sealed class OverallSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CommonService _commonService;

        public OverallSteps(ScenarioContext context, CommonService commonService)
        {
            _scenarioContext = context;
            _commonService = commonService;
        }

        [Given(@"I get the overall data")]
        public void GivenIGetTheOverallData()
        {
            var response = _commonService.GetOpenData("/prod/models?page=1");
            var overAll = JsonConvert.DeserializeObject<ModelResponse>(response.Content);
            _scenarioContext.Add(ScenarioKeys.KEY_API_RESPONSE, overAll);
            
        }

        [Then(@"I should see list of models sorted by RanK")]
        public void ThenIShouldSeeListOfModelsSortedByRanK()
        {
            var overAll = _scenarioContext.Get<ModelResponse>(ScenarioKeys.KEY_API_RESPONSE);
            Assert.IsTrue(overAll.TotalPages > 0);
            var list = overAll.Models;
            for (int i = 1; i < list.Count; i++)
            {
                Assert.IsTrue(list[i - 1].Rank < list[i].Rank);
            }
        }
    }
}
