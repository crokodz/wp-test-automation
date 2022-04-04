using WestPac.BuggyCarsRating.UITest.PageModels;
using Shouldly;
using WestPac.BuggyCarsRating.UITest.Constants;

namespace WestPac.BuggyCarsRating.UITest.StepDefinitions
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private VotePage _votePage;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"I should see '([^']*)'")]
        public void ThenIShouldSee(string message)
        {
            var html = _scenarioContext.Get<string>(ScenarioKeys.KEY_HTML_RESPONSE);
            html.ShouldContain(message);
        }
    }
}
