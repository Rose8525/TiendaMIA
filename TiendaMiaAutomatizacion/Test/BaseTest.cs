using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using TiendaMiaAutomatizacion.Report;
using TiendaMiaAutomatizacion.WebDriverImplementation;

namespace TiendaMiaAutomatizacion.Test
{
    public class BaseTest
    {
        protected IWebDriver webDriver;
        private string url = "http://www.tiendamia.com";
        private ExtentReports report;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            report = ReportManager.GetInstance();
        }

        [SetUp]
        public void SetUp()
        {
            var browser = ConfigurationManager.AppSettings[TestContext.CurrentContext.Test.Name];
            webDriver = WebDriverFactory.GetDriver(browser);
            test = report.CreateTest(TestContext.CurrentContext.Test.Name);
            webDriver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            ReportManager.FlushReport();
            if (webDriver != null)
                webDriver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportManager.FlushReport();
            if (webDriver != null)
                webDriver.Quit();
        }
    }
}
