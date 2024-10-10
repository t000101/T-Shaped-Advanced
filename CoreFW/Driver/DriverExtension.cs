using System;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CoreFW.Driver
{
    public static class DriverExtension
    {
        public static void GoToUrl(this IWebDriver driver, string url)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
            driver.Navigate().GoToUrl(url);
            driver.WaitForPageReady();
        }

        public static string GetTitle(this IWebDriver driver) => driver.Title;

        public static string GetPageSource(this IWebDriver driver) => driver.GetPageSource();

        public static string GetCurrentUrl(this IWebDriver driver) => driver.Url;

        public static void Click(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementClickable(locator, timeoutSec);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
        }

        public static void Input(this IWebDriver driver, By locator, string text, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementVisibility(locator, timeoutSec);
            element.Clear();
            Thread.Sleep(200);
            element.SendKeys(text);
        }

        public static string GetAttribute(this IWebDriver driver, By locator, string attribute, int timeoutSec)
        {
            string attributeValue = driver.WaitForElementExists(locator, timeoutSec).GetAttribute(attribute);
            return attributeValue;
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By locator, int timeoutSec)
        {
            IWebElement element = driver.FindElement(locator);
            return element.Displayed;
        }

        public static string GetText(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            return driver.WaitForElementVisibility(locator, timeoutSec).Text;
        }

        public static void Hover(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementExists(locator, timeoutSec);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void ExecuteJSClick(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementClickable(locator, timeoutSec);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void DoubleClick(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementClickable(locator, timeoutSec);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.DoubleClick().Perform();
        }

        public static void ExecuteJSDoubleClick(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementClickable(locator, timeoutSec);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].dblclick();", element);
        }

        public static void RightClick(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementClickable(locator, timeoutSec);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.ContextClick().Perform();
        }

        public static void SelectTextInCombobox(this IWebDriver driver, By locatorOfSelectTag, string textOfOptionTag)
        {
            IWebElement element = driver.WaitForElementExists(locatorOfSelectTag);
            var selectOption = new SelectElement(element);
            selectOption.SelectByText(textOfOptionTag);
        }

        public static void PressEscKey(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Escape);
            actions.Perform();
        }
        public static void PressEnter(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter);
            actions.Perform();
        }
        public static void RefreshPage(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }
        public static void PressHome(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Home);
            actions.Perform();
        }
        public static void ScrollPageFollowIndex(this IWebDriver driver, By locator, int index)
        {
            Actions actions = new Actions(driver);
            var elements = driver.FindElements(locator);
          
            actions.MoveToElement(elements[index - 1]);
            actions.Perform();
        }

        public static void MoveToElement(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            IWebElement element = driver.WaitForElementExists(locator, timeoutSec);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void MoveToTop(this IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollTo(0, 0);");
        }

        public static void SwitchTab(this IWebDriver driver)
        {
            IList<string> windows = driver.WindowHandles;
            foreach (string window in windows)
            {
                if (window != driver.CurrentWindowHandle)
                {
                    driver.SwitchTo().Window(window);
                }
            }
        }



        // ------ WAIT FUNCTIONS -----

        public static void WaitForPageReady(this IWebDriver driver, int timeoutSec = 120)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            wait.Until(webDiver => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static IWebElement WaitForElementClickable(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            return element;
        }

        public static IWebElement WaitForElementVisibility(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        public static IWebElement WaitForElementExists(this IWebDriver driver, By locator, int timeoutSec = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(locator));
            return element;
        }
    }
}
