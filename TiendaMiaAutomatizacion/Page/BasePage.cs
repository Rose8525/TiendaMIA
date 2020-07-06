using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMiaAutomatizacion.Page
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void CompleteField(IWebElement element, String value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        public void CompleteFieldWithoutClear(IWebElement element, String value)
        {
            element.Click();
            element.SendKeys(value);
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }
        public string GetElementText(IWebElement element)
        {
            return element.Text;
        }

        public string GetSelectedDropDown(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public string GetText(IWebElement element)
        {
            return element.GetAttribute("value");

        }

        public void SelectDropDown(IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);

        }
    }
}
