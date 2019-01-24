using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ValtechProject.StepDefinitions;

namespace ValtechProject.PageObjects
{
    public class HomePage : BasePage
    {
        public IWebElement AboutLink => DriverManager.Driver.FindElement(By.LinkText("ABOUT"));
        public IWebElement WorkLink => DriverManager.Driver.FindElement(By.LinkText("WORK"));
        public IWebElement ServicesLink => DriverManager.Driver.FindElement(By.LinkText("SERVICES"));


        public bool IsRecentBlogsSectionDisplayed(string sectionName)
        {
            var sectionHeader = DriverManager.Driver.FindElements(By.CssSelector("[class='block-header__heading']"));

            foreach (var x in sectionHeader)
            {
                if (x.Text.Equals(sectionName))
                {
                    return true;
                }
            }
            return false;
        }

        public BlogPage ChooseBlogsPositionedIn(string indexOfblogNo)
        {
            var indexNo  = int.Parse(Regex.Replace(indexOfblogNo, "[^0-9]", "")) -1;
            var blogsArticle  = DriverManager.Driver.FindElements(By.CssSelector(".bloglisting__item__heading"));
              
            blogsArticle[indexNo].Click();

            return new BlogPage();
        }


        public AboutPage NaviagteToAboutLink()
        {
            AboutLink.Click();
            return new AboutPage();
        }

        public WorkPage NaviagteToWorkLink()
        {
            WorkLink.Click();
            return new WorkPage();
        }

        public ServicesPage NaviagteToServicesLink()
        {
            ServicesLink.Click();
            return new ServicesPage();
        }
    }
}
