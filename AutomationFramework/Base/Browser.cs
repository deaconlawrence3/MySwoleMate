namespace AutomationFramework.Base
{
    public class Browser
    {
        private readonly DriverContext driverContext;

        public Browser(DriverContext driver)
        {
            driverContext = driver;
        }
    }
}
