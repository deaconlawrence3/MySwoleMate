using System;
using AutomationFramework.Configurations;


namespace AutomationFramework.Base
{
    public class Base
    {
        public readonly ParallelConfig _parallelConfig;
        public string DB = Settings.DBConnectionString;
        
       
        public Random randNum = new Random();

        public Base(ParallelConfig parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

    }
}