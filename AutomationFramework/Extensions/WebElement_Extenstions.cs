using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AutomationFramework.Extensions
{
    /*Description
    * This class holds all web elemtent extention
    * methods to be used on page objects.
    */

    public static class WebElement_Extensions
    {
        static Random randomGenerator = new Random();

        public static void SelectFromDropdown(this IWebElement element, string text)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
        }

        public static void SelectRandomValueFromDropDown(this IWebElement element)
        {
            SelectElement oSelect = new SelectElement(element);
            IList<IWebElement> options = oSelect.Options;

            int randvalue = randomGenerator.Next(1, options.Count);
            oSelect.SelectByIndex(randvalue);

        }

        public static string GetTextFromWithinElement(this IWebElement element)
        {
            string elementText;

            elementText = element.Text;
            if (elementText == "" || elementText == null)
            {
                elementText = element.GetAttribute("value");
            }

            if (elementText == "" || elementText == null)
            {
                elementText = element.GetAttribute("innerHTML");
            }

            return elementText;
        }

        public static string GetSelectedValue(this IWebElement element)
        {
            SelectElement oSelect = new SelectElement(element);
            var elementText = oSelect.SelectedOption.Text;
            return elementText;
        }

        public static void ScrollTo(this IWebElement element, ParallelConfig _parallelConfig)
        {
            Actions actions = new Actions(_parallelConfig.Driver);
            actions.MoveToElement(element).Perform();
        }

        public static void HoverAndClick(this IWebElement element, ParallelConfig _parallelConfig, IWebElement clickableElement)
        {
            Actions actions = new Actions(_parallelConfig.Driver);
            element.ScrollTo(_parallelConfig);
            _parallelConfig.Driver.WaitFive();
            clickableElement.Click();
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present exception"));
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsClickable(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed && element.Enabled;
                return ele;
            }
            catch
            {
                return false;
            }
        }

        public static IWebElement FindElement(this IWebDriver driver, ISearchContext sc, By locator, int timeOutInceconds = 20)
        {
            DefaultWait<ISearchContext> wait = new DefaultWait<ISearchContext>(sc);
            wait.Timeout = TimeSpan.FromSeconds(timeOutInceconds);
            wait.PollingInterval = TimeSpan.FromSeconds(3);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(x => GetElement(x, locator));
        }

        private static IWebElement GetElement(ISearchContext sc, By locator)
        {
            return sc.FindElement(locator);
        }

    }
}
