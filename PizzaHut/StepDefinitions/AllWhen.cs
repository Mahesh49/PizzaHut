using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Threading;

namespace PizzaHut.StepDefinitions
{
    [Binding]
    public class AllWhen:WebBrowser
    {

      

      

        [When(@"I localise")]
        public void WhenILocalise()
        {
            driver.FindElement(By.Id("PostCodeOrZip")).SendKeys("KT3 4ES");
            driver.FindElement(By.XPath(".//*[text()='Order Now' and @type='submit']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//*[text()='Start Your Order']")).Click();
            Thread.Sleep(2000);
            //driver.FindElement(By.XPath(".//*[@class='btn btn-default' and @title='Pizza']")).Click();
            
           
 

        }



    }
}
