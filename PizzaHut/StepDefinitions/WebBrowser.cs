using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace PizzaHut.StepDefinitions
{
    [Binding]
    public class WebBrowser
    {


        public static IWebDriver driver;

        [BeforeTestRun]
        public  static void StartBrowser()
        {
            if (ConfigurationManager.AppSettings["Browser"].Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }
            else
            driver = new ChromeDriver(@"C:\Users\Mahesh\Documents\Visual Studio 2010\Projects\PizzaHut\packages\WebDriver.ChromeDriver.win32.2.14.0.0\content\");
        }


        [AfterTestRun]
        public static void CloseBrowser()
        {
            driver.Close();
        }

    }
}
