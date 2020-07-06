using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMiaAutomatizacion.WebDriverImplementation
{
   public class FirefoxDriverCreator : WebDriverCreator
    {
        public override IWebDriver createWebDriver()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("dom.webnotifications.enabled", false);
            return new FirefoxDriver(firefoxOptions);
        }
    }
}
