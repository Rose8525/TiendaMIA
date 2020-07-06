using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace TiendaMiaAutomatizacion.Utils
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementTimeout(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }


        public static ReadOnlyCollection<IWebElement> FindElementsTimeout(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by).Displayed);
            }
            return driver.FindElement(by).Displayed;
        }

        public static bool IsElementEnable(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by).Enabled);
            }
            return driver.FindElement(by).Enabled;
        }

        public static bool IsElementClickeable(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by).Displayed && drv.FindElement(by).Enabled);
            }
            return driver.FindElement(by).Displayed && driver.FindElement(by).Enabled;
        }

        public static bool TryToClick(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (driver.IsElementClickeable(by, timeoutInSeconds))
            {
                try
                {
                    driver.FindElement(by).Click();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Elemento no clickeable");
                }
            }
            return false;
        }

        public static bool IsElementNotDisplayed(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => !drv.FindElement(by).Displayed);
            }
            return !driver.FindElement(by).Displayed;
        }
    }
}