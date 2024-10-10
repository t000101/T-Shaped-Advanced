using CoreFW.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFW.Page
{
    class LoginPage:BasePage
    {
        public Element emailTextBox = new Element(By.Id("email"));
        public Element passwordTextBox = new Element(By.Id("password"));
        public Element signInButton = new Element(By.XPath("//button[@data-cy='signin-button']"));
        protected string frame = "//iframe[@data-cy='ul-app-frame']";

        public void SwitchToFrame()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(frame)));
        }
        public void InputEmail(string email)
        {
            emailTextBox.Input(email);
        }

        public void InputPassword(string password)
        {
            passwordTextBox.Input(password);
        }
        
        public void ClickOnSignInButton()
        {
            signInButton.Click();
        }
    }
}
