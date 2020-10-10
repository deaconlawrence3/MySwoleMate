using AutomationFramework.ConfigurationElements;
using System.Configuration;

namespace AutomationFramework.Configurations
{
    class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            //Stores Browser and data path Information set in SkyGolf_Web.Specs > App.Config file
            Settings.BrowserConfig = ConfigurationManager.AppSettings["browser"];
            Settings.ChromeDriver = ConfigurationManager.AppSettings["ChromeDriver"];
            Settings.IEDriver = ConfigurationManager.AppSettings["IEDriver"];
            Settings.FireFoxDriver = ConfigurationManager.AppSettings["FireFoxDriver"];
            Settings.EdgeDriver = ConfigurationManager.AppSettings["EdgeDriver"];
            Settings.TestDataPath = ConfigurationManager.AppSettings["TestData"];
            Settings.DBConnectionString = ConfigurationManager.AppSettings["DBConn"];
        }
            //Establishes DB Connection String path
           // Settings.DBConnectionString = TestConfiguration.Settings.TestSettings["chrometest"].DBConnectionString;

    }
}
