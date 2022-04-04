using Newtonsoft.Json;
using WestPac.BuggyCarsRating.APITest.Constants;
using WestPac.BuggyCarsRating.APITest.Models;
using WestPac.BuggyCarsRating.UITest.Services;

namespace WestPac.BuggyCarsRating.APITest.StepDefinitions
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CommonService _commonService;

        public CommonSteps(ScenarioContext context, CommonService commonService)
        {
            _scenarioContext = context;
            _commonService = commonService;
        }

        [Given(@"I Login to get the token")]
        public void GivenILoginToGetTheToken()
        {
            var tokenResponse = _commonService.GetToken();
            Assert.IsTrue(!String.IsNullOrEmpty(tokenResponse.Access_token));
            Assert.IsTrue(!String.IsNullOrEmpty(tokenResponse.Refresh_token));
            Assert.IsTrue(tokenResponse.Expires_in>0);
            _scenarioContext.Add(ScenarioKeys.KEY_TOKEN, tokenResponse);
        }
    }
}
