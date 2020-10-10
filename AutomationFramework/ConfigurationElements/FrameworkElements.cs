using System.Configuration;

namespace AutomationFramework.ConfigurationElements
{
    public class FrameworkElements : ConfigurationElement
    {

        //Test Name
        [ConfigurationProperty("name", IsRequired = true)]
        public string TestName => (string)base["name"];

        //Base URL
        [ConfigurationProperty("url", IsRequired = true)]
        public string URL => (string)base["url"];

        //Browser used for tests
        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser => (string)base["browser"];

        //Logging Function - Will test utilized logging feature(Y/N)
        [ConfigurationProperty("isLog", IsRequired = false)]
        public string IsLog => (string)base["isLog"];

        //Log Path
        [ConfigurationProperty("logPath", IsRequired = false)]
        public string LogPath => (string)base["logPath"];

        //Database Connection String
        [ConfigurationProperty("DBConnectionString", IsRequired = true)]
        public string DBConnectionString => (string)base["DBConnectionString"];

        //Type of test run (i.e: Regression, functional, etc.)
        [ConfigurationProperty("testType", IsRequired = false)]
        public string TestType => (string)base["testType"];

        [ConfigurationProperty("providerName", IsRequired = false)]
        public string ProviderName => (string)base["providerName"];
    }
}
