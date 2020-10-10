using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace AutomationFramework.Extensions
{
    /*Description
    * This class house all the extention
    * methods that can be used in conjucntion
    * with a Web Driver instance.
    */

    public static class WebDriver_Extensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        public static IWebElement WaitUntilVisible(this IWebElement element, IWebDriver driver, int maxSeconds)
        {
            var stopWatch = Stopwatch.StartNew();
            while (element.IsClickable().Equals(false))
            {
                continue;
            }
            stopWatch.Stop();

            double milliseconds = stopWatch.ElapsedMilliseconds % 1000;
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxSeconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        //Will return two values from static method
        //public static Tuple<IWebElement, string> waitUntilVisible(this IWebElement element, IWebDriver driver, int maxSeconds)
        //{                     
        //    return Tuple.Create(new WebDriverWait(driver, TimeSpan.FromSeconds(maxSeconds)).Until(ExpectedConditions.ElementToBeClickable(element));
        //}

        public static void ScrollDownSome(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(250,350)");
        }

        public static void ScrollUpSome(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(-250,-350)");
        }

        public static void WaitFive(this IWebDriver driver)
        {
            //5 Seconds
            Thread.Sleep(5000);
        }

        public static void WaitTen(this IWebDriver driver)
        {
            //10 Seconds
            Thread.Sleep(10000);
        }

        public static void WaitTwenty(this IWebDriver driver)
        {
            //20 Seconds
            Thread.Sleep(20000);
        }

        public static void WaitThirty(this IWebDriver driver)
        {
            //30 Seconds
            Thread.Sleep(30000);
        }

        public static void Wait1Minute(this IWebDriver driver)
        {
            //1 Minute
            Thread.Sleep(60000);
        }

        public static void WaitOneHalfMinute(this IWebDriver driver)
        {
            //1.5 minutes
            Thread.Sleep(90000);
        }

        public static void Wait2Minutes(this IWebDriver driver)
        {
            //2 minutes
            Thread.Sleep(120000);
        }
    }

}
