using WestPac.BuggyCarsRating.UITest.PageModels;
using Shouldly;
using WestPac.BuggyCarsRating.UITest.Constants;

namespace WestPac.BuggyCarsRating.UITest.StepDefinitions
{
    [Binding]
    public sealed class OverallSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private OverallPage _overallPage;

        public OverallSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webContext = _scenarioContext.Get<WebContext>();
            _overallPage = new OverallPage(webContext);
        }


        [Given(@"I goto overall page")]
        public void GivenIGotoOverallPage()
        {
            var html = _overallPage.Goto("overall");
            html.ShouldNotBeNullOrEmpty();
            _scenarioContext.Remove(ScenarioKeys.KEY_HTML_RESPONSE);
            _scenarioContext.Add(ScenarioKeys.KEY_HTML_RESPONSE, html);
        }
    }
}
