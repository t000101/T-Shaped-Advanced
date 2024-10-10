using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using WebDriverManager.DriverConfigs.Impl;
using System.Drawing;
using System.Collections.Generic;

namespace CoreFW.Driver
{
    public class DriverManager
    {
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(string browserType, string mode, bool headless, string platform="", string remoteUrl="", string version = "Latest", string defaultDownloadFolder = null)
        {
            if (mode.ToUpper() == "LOCAL")
            {
                driver.Value = DriverFactory.LocalDriver(browserType, headless, version, defaultDownloadFolder);
            }
            else if (mode.ToUpper() == "REMOTE")
            {
                driver.Value = DriverFactory.RemoteDriver(browserType, headless, platform, remoteUrl, defaultDownloadFolder);
            }
            else throw new ArgumentException("Not supported Driver Mode");

            driver.Value.Manage().Window.Size = new Size(1920, 1080);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static IWebDriver GetDriver() => driver.Value;

        public static void QuitDriver()
        {
            driver.Value.Close();
            driver.Value.Quit();
            driver.Value.Dispose();
        }

    }
}
