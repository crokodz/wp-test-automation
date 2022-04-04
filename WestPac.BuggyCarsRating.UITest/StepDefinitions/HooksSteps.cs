using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WestPac.BuggyCarsRating.UITest.PageModels;

namespace WestPac.BuggyCarsRating.UITest.StepDefinitions
{
    [Binding]
    class HooksSteps
    {
        private string _browser;
        private readonly ScenarioContext _scenarioContext;
        public WebDriverWait DefaultWait;
        public static double WaitTime = 300;
        public static double ImplicitWaitTime = 5;
        private readonly TestContext _testContext;


        public HooksSteps(ScenarioContext scenarioContext, IObjectContainer container, TestContext testContext) {
            _browser = "chrome";
            _scenarioContext = scenarioContext;
            _testContext = testContext;
        }

        [BeforeScenario("selenium")]
        public void BeforeScenarioSelenium()
        {
            switch (_browser)
            {
                case "chrome":
                    _scenarioContext.Set(new WebContext(_testContext));
                    break;
            }
        }

        [AfterScenario("selenium")]
        public void AfterScenarioSelenium()
        {
            _scenarioContext.Get<WebContext>().Dispose();
        }

    }
}
