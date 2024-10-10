using CoreFW.Element;
using CoreFW.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestFW.TestData;
using System.Globalization;
using TestFW.DataObject;

namespace TestFW.Page
{
    class SearchPage:BasePage
    {
        public Element minPriceTextBox = new Element(By.Id("price_box_0"));
        public Element maxPriceTextBox = new Element(By.Id("price_box_1"));
        public Element starsHotels = new Element(By.XPath("//li[@data-selenium='hotel-item']//i[@data-selenium='hotel-star-rating']"));
        public Element nameHotels = new Element(By.XPath("//li[@data-selenium='hotel-item']//h3[@data-selenium='hotel-name']"));
        public Element locationHotels = new Element(By.XPath("//li[@data-selenium='hotel-item']//span[@data-selenium='area-city-text']"));
        public Element priceHotels = new Element(By.XPath("//li[@data-selenium='hotel-item']//span[@data-selenium='display-price']"));
        protected string hotelAddressLocator = "//span[@data-selenium='area-city-text'][{0}]";
        protected string hotelNameLocator = "//h3[@data-selenium='hotel-name'][{0}]";
        protected string hotelItemLocator = "(//li[@data-selenium='hotel-item'])[{0}]";
       

        public IList<IWebElement> GetStarHotels()
        {
            return starsHotels.FindElements();
        }

        public Element HotelItem(int index)
        {
            string xpath = string.Format(hotelItemLocator, index);
            return new Element(By.XPath(xpath));
        }

        public void ClickOnHotel(int index)
        {
            this.HotelItem(index).Click();
        }

        public Element HotelName(int index)
        {
            string xpath = string.Format(hotelNameLocator, index);
            return new Element(By.XPath(xpath));
        }

        public Element HotelAddress(int index)
        {
            string xpath = string.Format(hotelAddressLocator, index);
            return new Element(By.XPath(xpath));
        }

        public IList<IWebElement> GetLocationHotels()
        {
            return this.locationHotels.FindElements();
        }

        public IList<IWebElement> GetNameHotels()
        {
            return this.nameHotels.FindElements();
        }

        public void CheckAmountInList(int maxMount)
        {
            int amount;
            do
            {
                amount = GetStarHotels().Count();
                starsHotels.ScrollPageFollowIndex(amount);
            }while(amount <= maxMount);
        }

        public string GetHotelAddress(int index)
        {
            HotelAddress(index).MoveToElement();
            return HotelAddress(index).GetText().Split('-')[0].Trim();
        }

        public string GetHotelName(int index)
        {
            return HotelName(index).GetText();
        }

        public Hotel GetInfoHotel()
        {
            Hotel hotel = new Hotel();
            for (int i = 1; i <= 1; i++)
            {
                hotel.name = GetHotelName(i);
                hotel.location = GetHotelAddress(i);
            }
            return hotel;
        }


    }
}
