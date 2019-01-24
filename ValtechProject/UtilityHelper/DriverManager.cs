using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ValtechProject.StepDefinitions
{
    enum Browser
    {
        Firefox,
        Chrome,
    }

    [Binding]
    public static class DriverManager
    {
        public static IWebDriver Driver;

        private static readonly string ScreenShotSavePath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\ScreenShots\";


        [BeforeScenario]
        public static void BeforeScenario()
        {
            InitializeBrowser();
        }


        [AfterScenario]
        public static void AfterScenario()
        {
            TakeScreenShotWhenTestFails();
            CloseBrowser();
        }

        //[AfterFeature]
        //public static void AfterFeature()
        //{
        //    TakeScreenShotWhenTestFails();
        //    CloseBrowser();
        //}


        public static void InitializeBrowser()
        {
            Browser browser = Browser.Chrome;

            switch (browser)
            {
                case Browser.Firefox:
                    Driver = new FirefoxDriver();
                    break;

                case Browser.Chrome:
                    Driver = new ChromeDriver();
                    break;

                default:
                    Assert.Fail("Wrong Browser");
                    break;
            }

            Driver.Manage().Window.Maximize();
        }


        public static void CloseBrowser()
        {
            if (Driver != null)
            {
                Console.WriteLine("\r\n" + "Close Browser" + "\r\n");
                Driver.Quit();
                Driver = null;
            }
        }


        public static void TakeScreenShotWhenTestFails()
        {
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            var todayDate = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss tt");
            var screenShotName = $"{scenarioName}-{todayDate}";

            var scenarioPassed = ScenarioContext.Current.TestError == null;
            try
            {
                if (!scenarioPassed)
                {
                    Console.WriteLine(
                        $"\r\nTest scenario: {scenarioName} [Failed] \r\nSee screen shot with following name: {scenarioName}-{todayDate}");
                    CreateFolderInPathIfOneDoesNotExistAlready(ScreenShotSavePath);
                    var screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
                    screenShot.SaveAsFile(ScreenShotSavePath + screenShotName + ".png", ScreenshotImageFormat.Png);
                    TestContext.AddTestAttachment(ScreenShotSavePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static void CreateFolderInPathIfOneDoesNotExistAlready(string locationAndName)
        {
            try
            {
                if (!Directory.Exists(locationAndName))
                {
                    Directory.CreateDirectory(locationAndName);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
