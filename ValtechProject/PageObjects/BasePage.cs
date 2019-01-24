using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValtechProject.StepDefinitions;

namespace ValtechProject.PageObjects
{
    public class BasePage
    {
        public const int TimeDuration = 20;

        public IWebElement HaederTitle => DriverManager.Driver.FindElement(By.CssSelector("h1"));


        public void NavigateToValtechSite()
        {
            DriverManager.Driver.Navigate().GoToUrl("https://www.valtech.co.uk/");

            if (IsElementPresent(By.Id("CybotCookiebotDialogBodyButtonAccept")))
            {
                DriverManager.Driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept")).Click();
            }
        }

        public bool IsHaederTitleDisplayed()
        {
            return IsElementPresent(By.CssSelector("h1"));
        }

        public string GetPageTitle()
        {
            return HaederTitle.Text;
        }


        //*******************************************WaitUntil************************************************
        public void WaitUntilElementIsVisible(By locator, int waitDuration = TimeDuration)
        {
            var wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(waitDuration));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public bool WaitUntilElementIsNotVisible(By locator, int waitDuration = TimeDuration)
        {
            var wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(waitDuration));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));

        }

        //******************************************End of WaitUntil********************************************

        public bool IsElementPresent(By locator)
        {
            try
            {
                DriverManager.Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementEnabled(IWebElement elementName)
        {
            return elementName.Enabled;
        }
    }
}
