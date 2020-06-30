using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

using NUnit.Framework;
using NUnit.Framework.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;

namespace XPEssentials.Tests
{
    [TestFixture]
    public class TestBase : BaseClass
    {
        protected IWebDriver driver;
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            extent = new ExtentReports();
            string reportPath = @"D:\XPEssentials\";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void EachTimeSetUp()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            Logger.Info($"'{testName}'" + " starting");

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.automation.com/");

        }

        [TearDown]
        protected void CloseBrower()
        {
            driver.Close();
            
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            string resultString = $"'{TestContext.CurrentContext.Test.Name}' "
                                + Enum.GetName(typeof(TestStatus), testStatus);

            Logger.Info(resultString);

            if (testStatus == TestStatus.Failed)
            {
                Logger.Error(TestContext.CurrentContext.Result.Message);
                Logger.Error(TestContext.CurrentContext.Result.StackTrace);
                test.Log(Status.Fail, TestContext.CurrentContext.Result.Message);

            }

        }

        [OneTimeTearDown]
        public void OnetimeTearDown()
        {
            extent.Flush();
        }
    }
}
