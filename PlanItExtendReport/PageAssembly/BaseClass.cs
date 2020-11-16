using System;
using System.IO;
using System.Reflection;

using AventStack.ExtentReports;

using NUnit.Framework;
using NUnit.Framework.Interfaces;

using OpenQA.Selenium;

using PlanItExtendReport.Test;

namespace PlanItExtendReport.PageAssembly
{
    public class BaseClass
    {
        public IWebDriver driver;
        public ExtentTest test;
        protected Browsers browser;
        protected Page pages;
        [SetUp]
        public void initialize()
        {
            browser = new Browsers();
            pages = new Page(browser);
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Driver");
            browser.Init();
            test = SetupClass.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }


        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
: string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = TestContext.CurrentContext.Test.Name;
                    String screenShotPath = Capture(browser.GetDriver(), fileName);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            browser.Close();
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath + screenShotName + ".png");
            return localpath;
        }
    }
}