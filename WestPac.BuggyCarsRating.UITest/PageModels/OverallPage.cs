using OpenQA.Selenium;

namespace WestPac.BuggyCarsRating.UITest.PageModels
{
    public class OverallPage : BasePageModel
    {
        public OverallPage(WebContext context)
            : base(context)
        {
            base.WaitUntilPageReady();
        }

        public string Goto(string suburl)
        {
            Driver.Navigate().GoToUrl($"{buggyWebsite}{suburl}");
            var firstRow = By.XPath("//html/body/my-app/div/main/my-overall/div/div/table/tbody/tr[1]");
            return Driver.FindElement(firstRow).Text;
        }
    }
}

