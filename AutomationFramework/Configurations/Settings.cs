using System.Data.SqlClient;

namespace AutomationFramework.Configurations
{
    public class Settings
    {   
        public static string URL { get; set; }

        //Added to hold target testing browser
        public static string BrowserConfig { get; set; }

        //Path for elements below are in MySwoleMate_Specs > App.config
        
        public static string TestDataPath { get; set; }

        public static string ChromeDriver { get; set; }

        public static string FireFoxDriver { get; set; }

        public static string IEDriver { get; set; }

        public static string EdgeDriver { get; set; }
           
        public static SqlConnection ApplicationCon { get; set; }

        public static string DBConnectionString { get; set; }

         
    }
}
