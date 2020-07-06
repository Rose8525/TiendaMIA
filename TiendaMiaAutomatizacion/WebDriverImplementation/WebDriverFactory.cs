using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TiendaMiaAutomatizacion.WebDriverImplementation
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(String browser)
        {
            switch (browser)
            {
                case "chrome":
                    ChromeDriverCreator chromeDriver = new ChromeDriverCreator();
                    return chromeDriver.createWebDriver();
                case "firefox":
                    FirefoxDriverCreator firefoxDriver = new FirefoxDriverCreator();
                    return firefoxDriver.createWebDriver();
                default:
                    throw new Exception("Browser" + browser + "Not supported");                   

            }

        }
    }
}
