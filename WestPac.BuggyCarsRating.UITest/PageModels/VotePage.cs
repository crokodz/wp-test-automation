using OpenQA.Selenium;

namespace WestPac.BuggyCarsRating.UITest.PageModels
{
    public class VotePage : BasePageModel
    {
        public VotePage(WebContext context)
            : base(context)
        {
            base.WaitUntilPageReady();
        }

        public string Goto(string carId)
        {
            Driver.Navigate().GoToUrl($"{buggyWebsite}model/{carId}");
            var decription = By.XPath("//html/body/my-app/div/main/my-model/div/div[2]/div/p[1]");
            return Driver.FindElement(decription).Text;
        }

        public string Vote(string comment)
        {
            var tableBody = By.XPath("//html/body/my-app/div/main/my-model/div/div[3]/table/tbody");
            var tableBodyData = Driver.FindElement(tableBody).Text;
            if (tableBodyData.Contains(comment)) {
                return tableBodyData;
            }

            var commentInput = By.XPath("//*[@id=\"comment\"]");
            var voteButton = By.XPath("//html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[2]/div/button");
            Driver.FindElements(commentInput)[0].SendKeys(comment);
            Driver.FindElement(voteButton).Click();
            Driver.Navigate().Refresh();
            tableBody = By.XPath("//html/body/my-app/div/main/my-model/div/div[3]/table/tbody");
            return Driver.FindElement(tableBody).Text;
        }
    }
}

