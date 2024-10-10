using CoreFW.Driver;
using CoreFW.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFW.Component;
using TestFW.Page;
using TestFW.TestData;
using CoreFW.Helper;

namespace TestFW.Test
{
    class FavoriteListTest:BaseTest
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

        }

        [Test]
        public void AddHotelToFavoriteList()
        {
            BasePage basePage = new BasePage();
            SearchPage searchPage = new SearchPage();
            HomePage homePage = new HomePage();
            DayPicker dayPicker = new DayPicker();
            HotelDetailPage hotelDetailPage = new HotelDetailPage();
            FavoritePage favoritePage = new FavoritePage();
            FavoriteListPage favoriteListPage = new FavoriteListPage();
            DateTime today = DateTime.Now;
            DateTime start = DateTimeHelper.GetNextWeekday(today, DayOfWeek.Friday);
            DateTime end = start.AddDays(3);

            string[] wordWantReplace = new string[] {"Lat"} ;
            string place = StringHelper.CapitalizeString(Info.place, wordWantReplace);

            int numberRooms = Info.numberRooms;
            int numberAdults = Info.numberAdults;
            int numberChildren = Info.numberChildren;

            
            homePage.InputLocation(Info.place);
            homePage.ClickOnResultSearch(place);
            dayPicker.SelectDateRange(start, end);
            homePage.SelectFamilyTravelerType();
            homePage.SelectAmountMembers(numberRooms, numberAdults, numberChildren);
            homePage.ClickOnSearchButton();
            searchPage.driver.WaitForPageReady();

            searchPage.CheckAmountInList(5);
            Assert.GreaterOrEqual(searchPage.GetNameHotels().Count, 5);
            for (int i = 0; i < 5; i++)
            {
                string location = searchPage.GetLocationHotels()[i].Text.ToLower();
                StringAssert.Contains(place.ToLower(), location.ToLower());
            }

            searchPage.ClickOnHotel(1);
            basePage.SwitchTab();
            string nameOfDetailHotel = hotelDetailPage.GetHotelName();
            string locationOfDetailHotel = hotelDetailPage.GetHotelAddress();
            hotelDetailPage.ClickOnFavoriteIcon();
            basePage.PressHome();
            homePage.ClickOnLoginText();
            homePage.ClickOnSavedPropertiesList();
            favoritePage.ClickOnCollection(place);
            string nameOfHotelInFavoriteList = favoriteListPage.GetTextNameHotel(nameOfDetailHotel);
            string locationOfHotelInFavoriteList = favoriteListPage.GetTextLocationHotel(place);
            Assert.AreEqual(nameOfHotelInFavoriteList, nameOfDetailHotel);
            StringAssert.Contains(locationOfHotelInFavoriteList,locationOfDetailHotel );
        }

        [TearDown]
        public void TearDown()
        {
            FavoriteListPage favoriteListPage = new FavoriteListPage();
            favoriteListPage.ClickOnUnLike();
        }
    }
}
