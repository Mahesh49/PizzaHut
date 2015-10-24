using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaHut.StepDefinitions
{
    [Binding]
    public class AllThen:WebBrowser
    {
     

       
        [Then(@"I should see DropDowns")]
        public void ThenIShouldSeeDropDowns()
        {
            Assert.AreEqual(5, 5);
        }

    }
}
