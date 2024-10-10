using CoreFW.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFW.DataObject;

namespace TestFW.Page
{
    class HotelDetailPage : BasePage
    {
        public Element hotelName = new Element(By.XPath("//h1[@data-selenium='hotel-header-name']"));
        public Element hotelAddress = new Element(By.XPath("//span[@data-selenium='hotel-address-map']"));
        public Element favoriteIcon = new Element(By.XPath("//div[@data-element-name='favorite-heart']"));
        public Element anotherFavoriteIcon = new Element(By.XPath("//i[@data-element-name='favorite-heart']"));
        public Hotel infoHotel;


        public void ClickOnFavoriteIcon()
        {
            try
            {
                favoriteIcon.Click();
            }catch (Exception ex)
            {
                anotherFavoriteIcon.Click();
            }
        }

        public string GetHotelName()
        {
            hotelName.MoveToElement();
            return hotelName.GetText();
        }

        public string GetHotelAddress()
        {
            hotelAddress.MoveToElement();
            return hotelAddress.GetText();
        }

        public bool CheckInfoHotel(string name, string location)
        {
            bool status = false;
            if (GetHotelAddress().Contains(location))
            {
                return true;
            }
            return status;
        }

       
    }
}
