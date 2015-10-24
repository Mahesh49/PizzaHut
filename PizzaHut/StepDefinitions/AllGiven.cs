using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


namespace PizzaHut.StepDefinitions
{

    [Binding]
    public class AllGiven:WebBrowser
    {
        

        
        [Given(@"I am on HomePage")]
        public void GivenIAmOnHomePage()
        {
            driver.Navigate().GoToUrl("http://www.pizzahut.co.uk/");
        }

        [Then(@"I should see HomePage logo")]
        public void ThenIShouldSeeHomePageLogo()
        {
            Thread.Sleep(5000);
           // Assert.AreEqual("Sign In", driver.FindElement(By.LinkText("Sign In")).Text);

            Assert.AreEqual("Sign In",driver.FindElement(By.XPath("//a[@class='btn btn-info' and @href='/account/signin']")).Text);

            
        }


        [Then(@"I should see social links")]
        public void ThenIShouldSeeSocialLinks()
        {
            Thread.Sleep(5000);
           // driver.FindElement(By.LinkText("Sign In")).Click();
            driver.FindElement(By.XPath("//a[@class='btn btn-info' and @href='/account/signin']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("UserName")).SendKeys("mahesh4902@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456aQ");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@style='margin-bottom: 20px;' and @type='submit']")).Click();
            Thread.Sleep(5000);

            Assert.AreEqual("The email address or password provided is incorrect. Please try again.", driver.FindElement(By.XPath("html/body/div[3]/div/div[4]/div/div[1]/div/form/div[1]/ul/li")).Text);


        }

        public int a;

        [Given(@"I enter '(.*)'")]
        public void GivenIEnter(int p0)
        {
            this.a = p0;
        }

        [Then(@"I should see same number")]
        public void ThenIShouldSeeSameNumber()
        {
            Assert.AreEqual(10, a);
        }



        

        [Then(@"I am should be able to enter postcode from database")]
        public void ThenIAmShouldBeAbleToEnterPostcodeFromDatabase()
        {
            
            SqlConnection connection = new SqlConnection("Data Source=Mahesh-PC\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=SSPI");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT LastName FROM employee where EmployeeId=3", connection);
            //SqlCommand cmd2 = new SqlCommand("SET IDENTITY_INSERT employee ON", connection);
            SqlCommand cmd1 = new SqlCommand("insert into employee (LastName, DepartmentID) values ('Mahesh2',31)", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                driver.FindElement(By.Id("PostCodeOrZip")).SendKeys(reader.GetSqlValue(0).ToString());
                //driver.FindElement(By.Id("PostCodeOrZip")).SendKeys(reader["Column1"].ToString());

            }
            reader.Close();
            //SqlDataReader reader2 = cmd2.ExecuteReader();
            //reader2.Close();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Close();
            connection.Close();

            //if (employee.employeeid == 3)
            //{
            //    postcode = employee.postcode;
            //}

            
        }





       // [AfterScenario]
        public void closeBrowser()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\Mahesh\Documents\Visual Studio 2010\Projects\PizzaHut\ss" + Properties.Settings.Default.Step++ + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            driver.Close();

            
            Properties.Settings.Default.Save();
        }


        


    }
}
