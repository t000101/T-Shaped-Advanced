using CoreFW.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFW.Page
{
    class FavoriteListPage:BasePage
    {
        protected string nameHotel = "//div[@data-selenium='favorite-property-card']//div[text()='{0}']";
        protected string locationHotel = "//div[@data-selenium='favorite-property-card']//p[contains(text(),'{0}')]";
        public Element unLike = new Element(By.XPath("//div[@id='favorite-property-card-0']//img/following-sibling::div"));


        public void ClickOnUnLike()
        {
            unLike.Click();
        }

        public Element GetLocationHotel(string location)
        {
            return new Element(By.XPath(string.Format(locationHotel, location)));
        }

        public string GetTextLocationHotel(string location)
        {
            return GetLocationHotel(location).GetText();
        }

        public Element GetNameHotel (string name)
        {
            return new Element(By.XPath(string.Format(nameHotel, name)));
        }
        
        public string GetTextNameHotel(string name)
        {
            return GetNameHotel(name).GetText();
        }
    }
}
