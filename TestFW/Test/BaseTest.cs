using NUnit.Framework;
using System.IO;
using CoreFW.Report;
using CoreFW.Driver;
using OpenQA.Selenium;
using System;
using CoreFW.Config;
using System.Reflection;
using System.Threading;
using CoreFW.Helper;

[assembly: LevelOfParallelism(2)]
namespace TestFW.Test
{
    [TestFixture, Parallelizable(ParallelScope.Children)]
    public class BaseTest
    {
        readonly string projectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string downloadFolder;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            string reportPath = Path.Combine(projectPath, "TestResults");
            Console.WriteLine(reportPath);
            ExtentReportManager.Init(reportPath);
            ExtentReportManager.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            ExtentReportManager.Flush();
        }

        [SetUp]
        public void BeforeEach()
        {
            string version;
            int threadId = Thread.CurrentThread.ManagedThreadId;
            downloadFolder = Path.Combine(projectPath, "Downloads", $"Thread {threadId}");
            FileHelper.CreateDirIfNotExist(downloadFolder);

            ExtentReportManager.CreateNode(TestContext.CurrentContext.Test.Name);
            DriverManager.InitDriver(
                ConfigLoader.config["browser:name"],
                ConfigLoader.config["browser:mode"],
                false,
                ConfigLoader.config["browser:platform"],
                ConfigLoader.config["browser:remoteUrl"],
                
                defaultDownloadFolder: downloadFolder
            );
               
            DriverManager.GetDriver().GoToUrl(ConfigLoader.config["application:baseUrl"]);
        }

        [TearDown]
        public void AfterEach()
        {
            ExtentReportManager.UpdateReport(TestContext.CurrentContext, (ITakesScreenshot)DriverManager.GetDriver());
            DriverManager.QuitDriver();
        }

    }
}
