using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TiendaMiaAutomatizacion.MailHandler;
using TiendaMiaAutomatizacion.Report;
using TiendaMiaAutomatizacion.WebDriverImplementation;

namespace TiendaMiaAutomatizacion.Test
{
    public class BaseTest
    {
        [ThreadStatic]
        protected static IWebDriver webDriver;
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
            webDriver = WebDriverFactory.GetDriver(browser, ConfigurationManager.AppSettings["SeleniumGridUrl"]);
            test = report.CreateTest(TestContext.CurrentContext.Test.Name);
            webDriver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
             if (webDriver != null)
                webDriver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportManager.FlushReport();
            string subjectMessageResult = "All Test Passed";

            SendMailHandler.Instance.SubjectValue = subjectMessageResult + " " + SendMailHandler.Instance.SubjectValue;
            SendMailHandler.Instance.SetData(5, 1, ReportManager.GetUrl());
            SendMailHandler.Instance.SendSummaryReportMail();

            Console.WriteLine("Report: " + ReportManager.GetUrl());
            
        }
    }
}
