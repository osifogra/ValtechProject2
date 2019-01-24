using NUnit.Framework;
using TechTalk.SpecFlow;
using ValtechProject.PageObjects;

namespace ValtechProject.StepDefinitions
{
    [Binding]
    public sealed class ValtechStepDef
    {
        public HomePage HomePage = new HomePage();
        public BlogPage BlogPage = new BlogPage();
        public AboutPage AboutPage = new AboutPage();
        public WorkPage WorkPage = new WorkPage();
        public ServicesPage ServicesPage = new ServicesPage();
        public ContactPage ContactPage = new ContactPage();


        [Given(@"I choose to navigate to valtech")]
        public void GivenIChooseToNavigateToValtech()
        {
            HomePage.NavigateToValtechSite();
        }

        [Then(@"I should see the '(.*)' section displayed")]
        public void ThenIShouldSeeTheSectionDisplayed(string sectionName)
        {
            Assert.IsTrue(HomePage.IsRecentBlogsSectionDisplayed(sectionName));
        }

        [When(@"I choose to view the '(.*)' blog article")]
        public void WhenIChooseToViewTheBlogArticle(string blogPosition)
        {
            BlogPage = HomePage.ChooseBlogsPositionedIn(blogPosition);
        }


        [Then(@"I should see the page title displayed")]
        public void ThenIShouldSeeThePageTitleDisplayed()
        {
            Assert.IsTrue(BlogPage.IsHaederTitleDisplayed());
        }

        [When(@"I choose to navigate to '(.*)' page")]
        public void WhenIChooseToNavigateToPage(string linkName)
        {
            switch (linkName.ToLower())
            {
                case "about":
                    AboutPage = HomePage.NaviagteToAboutLink();
                    break;

                case "work":
                    WorkPage = HomePage.NaviagteToWorkLink();
                    break;

                case "services":
                    ServicesPage = HomePage.NaviagteToServicesLink();
                    break;

                case "contact":
                    AboutPage = HomePage.NaviagteToAboutLink();
                    ContactPage = AboutPage.NaviagteToContactPage();
                    break;

                default:
                    Assert.Fail("Wrong link name");
                    break;
            }
        }

        [Then(@"I should see '(.*)' title displayed")]
        public void ThenIShouldSeeTitleDisplayed(string pageTitle)
        {
            switch (pageTitle.ToLower())
            {
                case "about":
                    Assert.AreEqual(pageTitle, AboutPage.GetPageTitle());
                    break;

                case "work":
                    Assert.AreEqual(pageTitle, WorkPage.GetPageTitle());
                    break;

                case "services":
                    Assert.AreEqual(pageTitle, ServicesPage.GetPageTitle());
                    break;

                default:
                    Assert.Fail("Wrong page title name");
                    break;
            }
        }

        [Then(@"I should see a total '(.*)' offices")]
        public void ThenIShouldSeeATotalOffices(int numberOfOffices)
        {
            Assert.AreEqual(numberOfOffices, ContactPage.NumberOfOfficesInTotal());
        }
    }
}
