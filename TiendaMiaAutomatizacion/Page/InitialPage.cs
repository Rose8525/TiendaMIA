using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMiaAutomatizacion.Report;
using TiendaMiaAutomatizacion.Utils;

namespace TiendaMiaAutomatizacion.Page
{
    public class InitialPage : BasePage
    {
        private readonly IWebDriver _driver;

        public InitialPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement Country => _driver.FindElement(By.XPath("//a[@href='/uy/']")); 



        public ProductsPage selectCountry()
        {
            _driver.TryToClick(By.XPath("//a[@href='/uy/']"),3);
            return new ProductsPage(_driver);
        }


    }
}
