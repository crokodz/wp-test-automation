using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WestPac.BuggyCarsRating.UITest.PageModels
{
    public abstract class BasePageModel
    {
        public WebContext Context { get; private set; }
        public ChromeDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }

        private IWebDriver driver;
        protected string username = Environment.GetEnvironmentVariable("UserName");
        protected string password = Environment.GetEnvironmentVariable("UserPassword");
        protected string buggyWebsite = Environment.GetEnvironmentVariable("WebUrl");

        protected BasePageModel(WebContext context)
        {
            Context = context;
            Driver = context.WebDriver;
            Wait = context.DefaultWait;
            WaitUntilPageReady();
        }

        public virtual void WaitUntilPageReady()
        {
            Wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            SeleniumExtras.PageObjects.PageFactory.InitElements(Driver, this);
        }

        public IWebElement WaitUntilVisible(By by)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitUntilInVisible(By by)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }
    }
}
