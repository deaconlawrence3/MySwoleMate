using System;
using AutomationFramework.Base;
using AutomationFramework.Configurations;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium;
using System.IO;

namespace MySwoleMate_Specs
{
    [Binding]
    public class Hook : TestInitializeHook
    {
        private readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;


        public Hook(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeTest()
        {
            InitializeSettings();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            _parallelConfig.url = _parallelConfig.Driver.Url;
            if (_scenarioContext.TestError != null)
            {
               
            }
        }

        public void TestFailure()
        {
            var screenshot = _parallelConfig.Driver.TakeScreenshot();
            var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
            screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);            
            Console.WriteLine($"file:///{tempFileName}");
        }

    }
}
