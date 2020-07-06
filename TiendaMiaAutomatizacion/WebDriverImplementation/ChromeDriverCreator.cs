using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMiaAutomatizacion.WebDriverImplementation
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        public override IWebDriver createWebDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-notifications");
             return new ChromeDriver(chromeOptions);
        }
    }
}
