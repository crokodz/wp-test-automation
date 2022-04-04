using WestPac.BuggyCarsRating.UITest.PageModels;
using Shouldly;
using WestPac.BuggyCarsRating.UITest.Constants;

namespace WestPac.BuggyCarsRating.UITest.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private LoginPage _loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I login to the page")]
        public void GivenILoginToThePage()
        {
            var webContext = _scenarioContext.Get<WebContext>();
            _loginPage = new LoginPage(webContext);
            var html = _loginPage.Login();
            html.ShouldNotBeNullOrEmpty();
            _scenarioContext.Add(ScenarioKeys.KEY_HTML_RESPONSE, html);
        }
    }
}
