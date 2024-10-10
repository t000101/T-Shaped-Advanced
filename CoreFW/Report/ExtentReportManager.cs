using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CoreFW.Report
{
    public class ExtentReportManager
    {
        private static readonly ExtentReports report = new AventStack.ExtentReports.ExtentReports();
        private static AsyncLocal<ExtentTest> test = new AsyncLocal<ExtentTest>();
        private static AsyncLocal<ExtentTest> node = new AsyncLocal<ExtentTest>();

        public static void Init(string reportPath)
        {
            Console.WriteLine(reportPath);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath + @"\index.html");
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";
            htmlReporter.Config.DocumentTitle = "Automation Testing Framework";
            htmlReporter.Config.ReportName = "Automation Testing Report";
            report.AttachReporter(htmlReporter);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string name) => test.Value = report.CreateTest(name);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateNode(string name) => node.Value = test.Value.CreateNode(name);


        public static void Flush()
        {
            report.Flush();
        }

        public static void UpdateReport(TestContext context, ITakesScreenshot takesScreenshot)
        {
            TestContext.ResultAdapter result = context.Result;
            Console.WriteLine("Writing report");
            try
            {
                TestStatus status = result.Outcome.Status;

                switch(status)
                {
                    case TestStatus.Passed:
                        node.Value.Pass("Test Passed");
                        break;
                    case TestStatus.Failed:
                        string errorMessage = string.IsNullOrEmpty(result.Message)
                            ? ""
                            : string.Format("<pre>{0}</pre>", result.Message);
                        string stackTrace = string.IsNullOrEmpty(result.StackTrace)
                            ? ""
                            : string.Format("<pre>{0}</pre>", result.StackTrace);
                        var screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;

                        node.Value.Fail("Test Failed");
                        node.Value.Fail(errorMessage);
                        node.Value.Fail(stackTrace);
                        node.Value.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, context.Test.Name).Build());
                        break;
                    case TestStatus.Skipped:
                        node.Value.Skip("Test Skipped");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e);
            }


        }
    }
}
