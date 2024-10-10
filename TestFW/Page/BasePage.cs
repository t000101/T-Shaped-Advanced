using CoreFW.Driver;
using CoreFW.Element;
using OpenQA.Selenium;
using System.Linq;

namespace TestFW.Page
{
    class BasePage
    {
       public IWebDriver driver
        {
            get
            {
                return DriverManager.GetDriver();
            }
        }
        public void PressHome()
        {
            driver.PressHome();
        }
        public void SwitchTab()
        {
            driver.SwitchTab();
        }
       
    }
}
