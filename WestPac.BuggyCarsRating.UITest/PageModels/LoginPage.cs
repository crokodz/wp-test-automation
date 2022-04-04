using OpenQA.Selenium;

namespace WestPac.BuggyCarsRating.UITest.PageModels
{
    public class LoginPage : BasePageModel
    {
        public LoginPage(WebContext context)
            : base(context)
        {
            base.WaitUntilPageReady();
        }

        public string Login()
        {
            Driver.Navigate().GoToUrl(buggyWebsite);
            var loginField = By.XPath("//input");
            var loginButton = By.XPath("//button[@class='btn btn-success']");
            var header = By.XPath("//li[@class='nav-item']");

            Driver.FindElements(loginField)[0].SendKeys(username);
            Driver.FindElements(loginField)[1].SendKeys(password);
            Driver.FindElement(loginButton).Click();
            return Driver.FindElement(header).Text;
        }
    }
}

