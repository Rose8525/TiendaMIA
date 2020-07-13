using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TiendaMiaAutomatizacion.WebDriverImplementation
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(string browser, string seleniumGridUrl="")
        {
            switch (browser)
            {
                case "chrome":
                    ChromeDriverCreator chromeDriver = new ChromeDriverCreator();
                    return chromeDriver.createWebDriver();
                case "firefox":
                    FirefoxDriverCreator firefoxDriver = new FirefoxDriverCreator();
                    return firefoxDriver.createWebDriver();
                case "chrome-remote":
                    RemoteChromeDriverCreator remoteChromeDriver = new RemoteChromeDriverCreator(seleniumGridUrl);
                    return remoteChromeDriver.createWebDriver();
                case "firefox-remote":
                    RemoteFirefoxDriverCreator remoteFirefoxDriver = new RemoteFirefoxDriverCreator(seleniumGridUrl);
                    return remoteFirefoxDriver.createWebDriver();
                default:
                    throw new Exception("Browser" + browser + "Not supported");                   

            }

        }
    }
}
