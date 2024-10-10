using CoreFW.Element;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestFW.DataObject;

namespace TestFW.Page
{
    class HomePage : BasePage
    {
        protected Element AdsModel = new Element(By.XPath("//div[contains(@aria-label,'Modal Message')]"));
        protected Element closeAdsBtn = new Element(By.XPath("//button[@class='ab-close-button']"));
        protected Element searchLocationTextBox = new Element(By.XPath("//input[@data-selenium='textInput']"));
        protected string selectResultSeachLocator = "//li[@data-text='{0}']";
        protected Element occupancyCbo = new Element(By.XPath("//div[@data-selenium='occupancyBox']"));
        protected Element searchButton = new Element(By.XPath("//button[@data-selenium='searchButton']"));
        
        protected string tabLocator = "//li[@data-selenium = '{0}Tab']";
        public Element SignInButton = new Element(By.XPath("//button[@data-element-name='sign-in-button']"));
        public Element loginText = new Element(By.XPath("//span[@data-element-name='user-name']"));
        public Element anotherLoginText = new Element(By.XPath("//span[@data-selenium='login-text']"));
        protected string itemMenuAccount = "//a[@data-element-name='favorite-menu']";
        public string location = "//li[@data-selenium='hotel-item'][{0}]//span[@data-selenium='area-city-text']";
        //public Hotel infoHotel;

        public Element GetLocationHotel(int index)
        {
            return new Element(By.XPath(String.Format(location, index)));
        }

        public bool CheckLocationHotel(string address)
        {
            bool check = false;
            for (int i = 1; i <= 5; i++)
            {
                Hotel hotel = new Hotel
                {
                    location = GetLocationHotel(i).GetText()
                };
                if (hotel.location.ToLower().Contains(address.ToLower()))
                {
                    check = true;
                }
            }
            return check;
        }

        public Element GetSavedPropertiesList()
        {
            return new Element(By.XPath(itemMenuAccount));
        }

        public void ClickOnSavedPropertiesList()
        {
            GetSavedPropertiesList().Click();
        }

        public void ClickOnLoginText()
        {
            try
            {
                loginText.MoveToElement();
                loginText.Click();
            }catch (Exception ex)
            {
                anotherLoginText.MoveToElement();
                anotherLoginText.Click();
            }
        }

        public void ClickOnSignInButton()
        {
            this.SignInButton.Click();
        }

        public bool IsLoginTextDisplayed()
        {
            bool check;
            try
            {
                check = loginText.IsDisplayed();
            }
            catch (Exception)
            {
                check = anotherLoginText.IsDisplayed();
            }
            return check;
        }

        public void ClickOnSearchButton()
        {
            this.searchButton.Click();
        }

        public void ClickOnOccupancy()
        {
            this.occupancyCbo.Click();
        }

        public void ClickOnCloseAds()
        {
            try
            {
                this.AdsModel.WaitForElementVisibility();
                this.closeAdsBtn.Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void InputLocation(string location)
        {
            searchLocationTextBox.Input(location);
        }

        public Element GetResultSearch(string location)
        {
            return new Element (By.XPath(String.Format(selectResultSeachLocator, location)));
        }

        public void ClickOnResultSearch(string location)
        {
            this.GetResultSearch(location).Click();
        }


        protected string travelerType = "//div[@data-selenium='{0}']";
        public Element FamilyTravelerType()
        {
            return new Element(By.XPath(string.Format(travelerType, "traveler-families")));
        }

        protected string numberOccupancyLocator = "//span[contains(@data-selenium, '{0}-value')]";
        public Element NumberRoom()
        {
            string xpath = string.Format(numberOccupancyLocator, "room");
            return new Element(By.XPath(xpath));
        }

        public Element NumberAdult()
        {
            string xpath = string.Format(numberOccupancyLocator, "adult");
            return new Element(By.XPath(xpath));
        }

        public Element NumberChildren()
        {
            string xpath = string.Format(numberOccupancyLocator, "children");
            return new Element(By.XPath(xpath));
        }

        protected string increaseDecreaseAmountLocator = "//div[@data-selenium='{0}']//span[@data-selenium='{1}']";
        public Element IncreaseRoomBtn()
        {
            string xpath = string.Format(increaseDecreaseAmountLocator, "occupancyRooms", "plus");
            return new Element(By.XPath(xpath));
        }

        public Element DecreaseRoomBtn()
        {
            string xpath = string.Format(increaseDecreaseAmountLocator, "occupancyRooms", "minus");
            return new Element(By.XPath(xpath));
        }

        public Element IncreaseAdultBtn()
        {
            string xpath = string.Format(increaseDecreaseAmountLocator, "occupancyAdults", "plus");
            return new Element(By.XPath(xpath));
        }

        public Element DecreaseAdultBtn()
        {
            string xpath = string.Format(increaseDecreaseAmountLocator, "occupancyAdults", "minus");
            return new Element(By.XPath(xpath));
        }

        public Element IncreaseChildrenBtn()
        {
            string xpath = string.Format(increaseDecreaseAmountLocator, "occupancyChildren", "plus");
            return new Element(By.XPath(xpath));
        }

        public Element DecreaseChildrenBtn()
        {
            string xpath = string.Format(increaseDecreaseAmountLocator, "occupancyChildren", "minus");
            return new Element(By.XPath(xpath));
        }

        public void SetNumberRoom(int amount)
        {
            int currentAmount = int.Parse(NumberRoom().GetText());
            int diff = Math.Abs(amount - currentAmount);
            Element btn = (amount > currentAmount) ? IncreaseRoomBtn() : DecreaseRoomBtn();

            for (int i = 0; i < diff; i++)
            {
                btn.Click();
            }
        }

        public void SetNumberAdult(int amount)
        {
            int currentAmount = int.Parse(NumberAdult().GetText());
            int diff = Math.Abs(amount - currentAmount);
            Element btn = (amount > currentAmount) ? IncreaseAdultBtn() : DecreaseAdultBtn();

            for (int i = 0; i < diff; i++)
            {
                btn.Click();
            }
            
        }

        public void SetNumberChildren(int amount)
        {
            int currentAmount = int.Parse(NumberChildren().GetText());
            int diff = Math.Abs(amount - currentAmount);
            Element btn = (amount > currentAmount) ? IncreaseChildrenBtn() : DecreaseChildrenBtn();

            for (int i = 0; i < diff; i++)
            {
                btn.Click();
            }
        }

        public void SelectAmountMembers(int rooms, int adults, int childrens)
        {
            SetNumberRoom(rooms);
            SetNumberAdult(adults);
            SetNumberChildren(childrens);
        }

        public void SelectFamilyTravelerType()
        {
            this.FamilyTravelerType().Click();
        }

    }
}
