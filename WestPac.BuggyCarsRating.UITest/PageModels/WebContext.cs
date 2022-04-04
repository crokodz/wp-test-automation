using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WestPac.BuggyCarsRating.UITest.Support;

namespace WestPac.BuggyCarsRating.UITest.PageModels
{
    public class WebContext : IDisposable
    {
        public static double ImplicitWaitTime = 5;
        public static double WaitTime = 300;

        public ChromeDriver WebDriver { get; set; }
        public TestContext TestContext { get; set; }

        public WebDriverWait DefaultWait;

        public WebContext(TestContext context)
        {
            TestContext = context;
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var options = new ChromeOptions();
            if (bool.TryParse(context.Properties.GetValue("SELENIUM_USE_INCOGNITO")?.ToString(), out bool result) ? result : false)
                options.AddArgument("incognito");

            WebDriver = new ChromeDriver(path, options);
            WebDriver.Manage().Window.Maximize(); // max window so that webpages don't use mobile / tablet views
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTime);
            DefaultWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTime));
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
