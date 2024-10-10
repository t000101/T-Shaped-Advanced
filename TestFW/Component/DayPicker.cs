using CoreFW.Driver;
using CoreFW.Element;
using OpenQA.Selenium;
using System;

namespace TestFW.Component
{
    public class DayPicker
    {
        private readonly IWebDriver driver = DriverManager.GetDriver();

        public Element nextMonthBtn = new Element(By.XPath("//span[@data-selenium='calendar-next-month-button']"));
        public Element previousMonthBtn = new Element(By.XPath("//span[@data-selenium='calendar-previous-month-button']"));

        protected string monthLocator = "(//div[contains(@class, 'DayPicker-Caption')]//div)[{0}]";
        public Element LeftMonth()
        {
            string xpath = string.Format(monthLocator, 1);
            return new Element(By.XPath(xpath));
        }

        public Element RightMonth()
        {
            string xpath = string.Format(monthLocator, 2);
            return new Element(By.XPath(xpath));
        }

        protected string dayLocator = "//div[contains(@class, 'Picker-Day') and @aria-label='{0}']";
        public Element Day(DateTime date)
        {
            string label = date.ToString("ddd MMM dd yyyy");
            string xpath = string.Format(dayLocator, label);
            return new Element(By.XPath(xpath));
        }

        public void SelectDateRange(DateTime startDate, DateTime endDate)
        {
            Element startDay = Day(startDate);
            Element endDay = Day(endDate);

            NavigateToMonth(startDate);
            startDay.Click();

            NavigateToMonth(endDate);
            endDay.Click();
        }

        public void NavigateToMonth(DateTime date)
        {
            Element leftMonth = LeftMonth();

            DateTime leftMonthDT = DateTime.Parse(leftMonth.GetText());
            if (date.Month > leftMonthDT.Month)
            {
                int diff = date.Month - leftMonthDT.Month;
                for (int t = 0; t < diff; t++)
                {
                    nextMonthBtn.Click();
                }
            }
            else if (date.Month < leftMonthDT.Month)
            {
                int diff = leftMonthDT.Month - date.Month;
                for (int t = 0; t < diff; t++)
                {
                    previousMonthBtn.Click();
                }
            }
        }
    }
}
