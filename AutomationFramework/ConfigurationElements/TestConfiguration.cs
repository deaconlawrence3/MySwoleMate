using System.Configuration;

namespace AutomationFramework.ConfigurationElements
{
    public class TestConfiguration : ConfigurationSection
    {
        public static TestConfiguration Settings { get; } = (TestConfiguration)ConfigurationManager.GetSection("TestConfiguration");

        [ConfigurationProperty("testSettings")]
        public FrameworkElementCollection TestSettings => (FrameworkElementCollection)base["testSettings"];

    }
}
