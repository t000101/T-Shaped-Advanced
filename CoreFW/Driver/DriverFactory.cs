using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace CoreFW.Driver
{
    class DriverFactory
    {
        public static IWebDriver LocalDriver(string browserType, bool headless, string version = "Latest", string defaultDownloadFolder = null)
        {   
            if (browserType.ToUpper() == "CHROME")
            {
                return LocalChromeDriver(ChromeOpts(headless, defaultDownloadFolder), "102.0.5005.61");
            }
            else if (browserType.ToUpper() == "FIREFOX")
            {
                return LocalFirefoxDriver(FirefoxOpts(headless, defaultDownloadFolder), version);
            }
            else if (browserType.ToUpper() == "EDGE")
            {
                return LocalEdgeDriver(EdgeOpts(headless, defaultDownloadFolder), version);
            }
            else throw new ArgumentException($"Not supported Browser Type: {browserType}");
        }

        public static IWebDriver RemoteDriver(string browserType, bool headless, string platform, string remoteUrl, string defaultDownloadFolder = null)
        {
            if (browserType.ToUpper() == "CHROME")
            {
                return RemoteChromeDriver(ChromeOpts(headless, defaultDownloadFolder), platform, remoteUrl);
            }
            else if (browserType.ToUpper() == "FIREFOX")
            {
                return RemoteFirefoxDriver(FirefoxOpts(headless, defaultDownloadFolder), platform, remoteUrl);
            }
            else if (browserType.ToUpper() == "EDGE")
            {
                return RemoteEdgeDriver(EdgeOpts(headless, defaultDownloadFolder), platform, remoteUrl);
            }
            else throw new ArgumentException($"Not supported Browser Type: {browserType}");
        }

        // ----- CHROME -----
        private static ChromeOptions ChromeOpts(bool headless, string defaultDownloadFolder)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddUserProfilePreference("download.default_directory", defaultDownloadFolder);
            if (headless) options.AddArgument("--headless");

            return options;
        }

        private static IWebDriver LocalChromeDriver(ChromeOptions options ,string version = "Lastest")
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), version);
            return new ChromeDriver(options);
        }

        private static IWebDriver RemoteChromeDriver(ChromeOptions options, string platform, string remoteUrl)
        {
            options.PlatformName = platform.ToUpper();
            return new RemoteWebDriver(new Uri(remoteUrl), options.ToCapabilities(), TimeSpan.FromMinutes(1));
        }

        // ----- FIREFOX -----
        private static FirefoxOptions FirefoxOpts(bool headless, string defaultDownloadFolder)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--no-sandbox");
            options.AddAdditionalOption("browser.download.manager.showWhenStarting", "false");
            options.AddAdditionalOption("browser.download.dir", defaultDownloadFolder);
            if (headless)
            {
                options.AddArgument("--headless");
            }

            return options;
        }

        public static IWebDriver LocalFirefoxDriver(FirefoxOptions options, string version = "Latest")
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }

        private static IWebDriver RemoteFirefoxDriver(FirefoxOptions options, string platform, string remoteUrl)
        {
            options.PlatformName = platform.ToUpper();
            return new RemoteWebDriver(new Uri(remoteUrl), options.ToCapabilities(), TimeSpan.FromMinutes(1));
        }

        // ----- EDGE -----
        private static EdgeOptions EdgeOpts(bool headless, string defaultDownloadFolder)
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("--no-sandbox");
            options.AddUserProfilePreference("download.default_directory", defaultDownloadFolder);
            if (headless)
            {
                options.AddArgument("--headless");
            }

            return options;
        }

        public static IWebDriver LocalEdgeDriver(EdgeOptions options, string version = "Latest")
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver(options);
        }

        private static IWebDriver RemoteEdgeDriver(EdgeOptions options, string platform, string remoteUrl)
        {
            options.PlatformName = platform.ToUpper();
            return new RemoteWebDriver(new Uri(remoteUrl), options.ToCapabilities(), TimeSpan.FromMinutes(1));
        }
    }
}
