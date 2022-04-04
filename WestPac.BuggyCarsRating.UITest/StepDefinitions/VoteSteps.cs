using WestPac.BuggyCarsRating.UITest.PageModels;
using Shouldly;
using WestPac.BuggyCarsRating.UITest.Constants;

namespace WestPac.BuggyCarsRating.UITest.StepDefinitions
{
    [Binding]
    public sealed class VoteSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private VotePage _votePage;

        public VoteSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webContext = _scenarioContext.Get<WebContext>();
            _votePage = new VotePage(webContext);
        }

        [When(@"I goto model page with car id '([^']*)'")]
        public void WhenIGotoModelPageWithCarId(string carId)
        {
            var html = _votePage.Goto(carId);
            html.ShouldNotBeNullOrEmpty();
            _scenarioContext.Remove(ScenarioKeys.KEY_HTML_RESPONSE);
            _scenarioContext.Add(ScenarioKeys.KEY_HTML_RESPONSE, html);
        }

        [Then(@"I add comment '([^']*)'")]
        public void ThenIAddComment(string comment)
        {
            var html = _votePage.Vote(comment);
            html.ShouldContain(comment);
            _scenarioContext.Remove(ScenarioKeys.KEY_HTML_RESPONSE);
            _scenarioContext.Add(ScenarioKeys.KEY_HTML_RESPONSE, html);
        }
    }
}
