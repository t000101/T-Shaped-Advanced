using CoreFW.Driver;
using CoreFW.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestFW.Component;
using TestFW.DataObject;
using TestFW.Page;
using TestFW.TestData;

namespace TestFW.Test
{
    public class HotelDetailTest:BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            LoginPage loginPage = new LoginPage();
            HomePage homePage = new HomePage();
            homePage.ClickOnCloseAds();
            homePage.ClickOnSignInButton();
            loginPage.SwitchToFrame();
            loginPage.InputEmail(Account.email);
            loginPage.InputPassword(Account.password);
            loginPage.ClickOnSignInButton();
            homePage.ClickOnCloseAds();
            Assert.IsTrue(homePage.IsLoginTextDisplayed());
;
        }
        [Test]
        public void DetailHotel()
        {
            BasePage basePage = new BasePage();
            SearchPage searchPage = new SearchPage();
            HomePage homePage = new HomePage();
            DayPicker dayPicker = new DayPicker();
            HotelDetailPage hotelDetailPage = new HotelDetailPage();
            DateTime today = DateTime.Now;
            DateTime start = DateTimeHelper.GetThreeDayNextTomorrow(today, DateTime.Today.AddDays(2).DayOfWeek);
            DateTime end = start.AddDays(3);

            string[] wordWantReplace = new string[] { "Lat" };
            string place = StringHelper.CapitalizeString(Info.place, wordWantReplace);
            int numberRooms = Info.numberRooms;
            int numberAdults = Info.numberAdults;
            int numberChildren = Info.numberChildren;
            homePage.InputLocation(place);
            homePage.ClickOnResultSearch(place);
            dayPicker.SelectDateRange(start, end);

            homePage.SelectFamilyTravelerType();
            homePage.SelectAmountMembers(numberRooms, numberAdults, numberChildren);

            homePage.ClickOnSearchButton();
            searchPage.driver.WaitForPageReady();

            searchPage.CheckAmountInList(5);
            Assert.GreaterOrEqual(searchPage.GetNameHotels().Count, 5);
            Assert.IsTrue(homePage.CheckLocationHotel(place.ToLower()));
            //for (int i = 0; i < 5; i++)
            //{
            //    string location = searchPage.GetLocationHotels()[i].Text.ToLower();
            //    StringAssert.Contains(place.ToLower(), location.ToLower());
            //}

            //Hotel hotel = new Hotel
            //{
            //    name = searchPage.GetHotelName(1),
            //    location = searchPage.GetHotelAddress(1)
            //};
           
            searchPage.ClickOnHotel(1);
            basePage.driver.SwitchTab();
            Assert.AreEqual(hotelDetailPage.GetHotelName(), searchPage.GetInfoHotel().name);
            StringAssert.Contains(searchPage.GetInfoHotel().location, hotelDetailPage.GetHotelAddress());   
           
        }
      

    }
}
