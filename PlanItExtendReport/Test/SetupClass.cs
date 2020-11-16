using System;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

using NUnit.Framework;

namespace PlanItExtendReport.Test
{
    [SetUpFixture]
    public class SetupClass
    {
        public static ExtentReports extent;
        [OneTimeSetUp]
        protected void Setup()
        {
            extent = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("//Reports", "");
            // DirectoryInfo di = Directory.CreateDirectory(dir + "Test_Execution_Reports");
            var htmlReporter = new ExtentHtmlReporter(dir + "//Reports" + "//Automation_Report.html");
            extent.AddSystemInfo("Environment", "Journey of Quality");
            extent.AddSystemInfo("User Name", "Shan");
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            extent.Flush();
        }
    }
}
