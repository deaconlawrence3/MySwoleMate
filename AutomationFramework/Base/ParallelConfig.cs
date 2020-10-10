using AutomationFramework.Helpers;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;


namespace AutomationFramework.Base
{
    public class ParallelConfig
    {
        public RemoteWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }

        public DatabaseHelpers queryResults = new DatabaseHelpers();

        public string testName = ScenarioContext.Current.ScenarioInfo.Title.ToString();

        public string BrowserName { get; set; }

        public string url { get; set; }
    }
}
