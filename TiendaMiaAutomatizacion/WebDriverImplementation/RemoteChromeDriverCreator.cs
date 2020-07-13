using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMiaAutomatizacion.WebDriverImplementation
{
    public class RemoteChromeDriverCreator : WebDriverCreator
    {
        private string Url;
        public RemoteChromeDriverCreator(string Url)
        {
            this.Url = Url;
        }
        public override IWebDriver createWebDriver()
        {
            return new RemoteWebDriver(new Uri(Url), new ChromeOptions());
        }

        public static implicit operator RemoteChromeDriverCreator(ChromeDriverCreator v)
        {
            throw new NotImplementedException();
        }
    }
}
