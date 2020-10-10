using AutomationFramework.Configurations;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using System;

namespace AutomationFramework.Base
{
    public class TestInitializeHook : Steps
    {
        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Open Browser
            OpenBrowser(Settings.BrowserConfig);
         
        }

        private void OpenBrowser(string browserType)
        {
            switch (browserType)
            {
                case "IE":
                    var IEcapabilities = new InternetExplorerOptions();
                    IEcapabilities.IgnoreZoomLevel = true;
                    _parallelConfig.Driver = new InternetExplorerDriver(Settings.IEDriver, IEcapabilities, TimeSpan.FromSeconds(180));
                    _parallelConfig.BrowserName = IEcapabilities.BrowserName;
                    break;

                case "Firefox":
                    var FFcapabilities = new FirefoxOptions();
                    FFcapabilities.AcceptInsecureCertificates = true;
                    _parallelConfig.Driver = new FirefoxDriver(Settings.FireFoxDriver, FFcapabilities, TimeSpan.FromSeconds(180));
                    _parallelConfig.BrowserName = FFcapabilities.BrowserName;
                    break;

                case "Chrome":
                    var CHcapabilities = new ChromeOptions();
                    CHcapabilities.AddArgument("no-sandbox");
                    _parallelConfig.Driver = new ChromeDriver(Settings.ChromeDriver, CHcapabilities, TimeSpan.FromSeconds(180));
                    _parallelConfig.BrowserName = CHcapabilities.BrowserName;
                    break;

                case "Edge":
                    var Edgecapabilities = new EdgeOptions();
                    _parallelConfig.Driver = new EdgeDriver(Settings.EdgeDriver, Edgecapabilities, TimeSpan.FromSeconds(180));
                    _parallelConfig.BrowserName = Edgecapabilities.BrowserName;
                    break;
            }
        }
    }
}
