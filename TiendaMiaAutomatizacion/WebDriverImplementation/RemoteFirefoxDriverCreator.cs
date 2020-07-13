using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMiaAutomatizacion.WebDriverImplementation
{
    public class RemoteFirefoxDriverCreator : WebDriverCreator
    {
        private string Url;
        public RemoteFirefoxDriverCreator(string Url)
        {
            this.Url = Url;
        }
        public override IWebDriver createWebDriver()
        {
            return new RemoteWebDriver(new Uri(Url), new FirefoxOptions());
        }
    }
}
