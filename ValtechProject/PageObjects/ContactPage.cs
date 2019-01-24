using OpenQA.Selenium;
using ValtechProject.StepDefinitions;

namespace ValtechProject.PageObjects
{
    public class ContactPage : BasePage
    {
        public int NumberOfOfficesInTotal()
        {
            return DriverManager.Driver.FindElements(By.CssSelector(".office__heading")).Count;
        }
    }
}
