using CoreFW.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CoreFW.Element
{
    public class Element
    {
        private readonly By locator;
        private int timeoutSec;
        private IWebDriver driver;

        public Element(By locator, int timeoutSec = 30)
        {
            this.locator = locator;
            this.timeoutSec = timeoutSec;
            this.driver = DriverManager.GetDriver();
        }

        public IList<IWebElement> FindElements() => this.driver.FindElements(this.locator);

        public IWebElement FindElement() => this.driver.FindElement(this.locator);

        public void SetTimeout(int timeoutSec) => this.timeoutSec = timeoutSec;

        public By GetLocator() => this.locator;

        public void Click() => this.driver.Click(this.locator, this.timeoutSec);

        public void Input(string text) => this.driver.Input(this.locator, text, this.timeoutSec);

        public string GetAttribute(string attribute) => this.driver.GetAttribute(this.locator, attribute, this.timeoutSec);

        public bool IsDisplayed() => this.driver.IsElementDisplayed(this.locator, this.timeoutSec);

        public string GetText() => this.driver.GetText(this.locator, this.timeoutSec);

        public IWebElement WaitForElementVisibility() => this.driver.WaitForElementVisibility(this.locator, this.timeoutSec);

        public IWebElement WaitForElementExists() => this.driver.WaitForElementExists(this.locator, this.timeoutSec);

        public void Hover() => this.driver.Hover(this.locator, this.timeoutSec);

        public void ExecuteJSClick() => this.driver.ExecuteJSClick(this.locator, this.timeoutSec);

        public void DoubleClick() => this.driver.DoubleClick(this.locator, this.timeoutSec);

        public void ExecuteJSDoubleClick() => this.driver.ExecuteJSDoubleClick(this.locator, this.timeoutSec);

        public void RightClick() => this.driver.RightClick(this.locator, this.timeoutSec);

        public void ScrollPageFollowIndex(int index) => this.driver.ScrollPageFollowIndex(this.locator, index);

        public void PressEnter() => this.driver.PressEnter();

        public void PressHome() => this.driver.PressHome();

        public void MoveToElement() => this.driver.MoveToElement(this.locator, this.timeoutSec);
    }
}
