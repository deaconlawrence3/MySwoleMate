using OpenQA.Selenium;
using System;
using AutomationFramework.Helpers;
using AutomationFramework.Extensions;
using NUnit.Framework;
using AutomationFramework.Configurations;
using AutomationFramework.PageObjects;

namespace AutomationFramework.Base
{
    public class BasePage : Base
    {
        public BasePage(ParallelConfig parellelConfig) : base(parellelConfig)
        {

        }

    }
}
