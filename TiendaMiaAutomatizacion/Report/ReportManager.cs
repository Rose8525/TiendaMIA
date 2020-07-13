using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using sun.tools.java;
using System;
using System.IO;
using System.Reflection;
using Environment = System.Environment;

namespace TiendaMiaAutomatizacion.Report
{
    public class ReportManager
    {
        private static ExtentHtmlReporter htmlReporter;

        private static ExtentReports extent;
        private static string reportPath;
        private static readonly object padlock = new object();

        private ReportManager()
        {

        }

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                lock (padlock)
                {
                    if (extent == null)
                    {
                        reportPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @".\Report\CreatedReport\TestReport.html";
                        htmlReporter = new ExtentHtmlReporter(reportPath);
                        extent = new ExtentReports();
                        extent.AttachReporter(htmlReporter);
                        extent.AddSystemInfo("Enviroment", "QA");

                        string extentConfigPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\extent-config.xml";
                        Console.WriteLine(extentConfigPath);
                        htmlReporter.LoadConfig(extentConfigPath);

                    }
                }
            }

            return extent;
        }

        public static MediaEntityModelProvider ScreenShot(IWebDriver webDriver)
        {
            string guid = new Guid().ToString();
            /*((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile(@"./Report/CreatedReport/" + guid + ".png", ScreenshotImageFormat.Png);
            var mediaentity = MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\Usuario\Documents\Reports\s1.png");
            test.AddScreenCaptureFromPath*/
            var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot().AsBase64EncodedString;
            var mediaentity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();
            
            return mediaentity;
        }

        public static void FlushReport()
        {
            extent.Flush();
        }

        public static string GetUrl()
        {
            return  reportPath;
        }
    }
}
