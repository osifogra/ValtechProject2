using OpenQA.Selenium;
using ValtechProject.StepDefinitions;

namespace ValtechProject.PageObjects
{
    public class AboutPage : BasePage
    {
        public IWebElement Contact => DriverManager.Driver.FindElement(By.LinkText("Our offices"));

        public ContactPage NaviagteToContactPage()
        {
            Contact.Click();
            return new ContactPage();
        }

       
    }
}
