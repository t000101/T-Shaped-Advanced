using CoreFW.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFW.Page
{
    class FavoritePage:BasePage
    {
        protected string collection = "//h4[contains(text(), '{0}')]";

        public Element GetCollection(string collectionName)
        {
            return new Element(By.XPath(string.Format(collection, collectionName)));
        }
        public void ClickOnCollection(string collectionName)
        {
            GetCollection(collectionName).Click();  
        }
    }
}
