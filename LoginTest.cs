using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace QA
{
    [TestFixture]
    public class LoginTests 
    {
        public string Url = "https://the-internet.herokuapp.com/login";
        public int SleepTime = 500;
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = Url;
        }
        
        //Passing test with correct username and password. 
        [TestCase ("tomsmith", "SuperSecretPassword!")]
        public void PassingTest(string username, string password)
        {     
            var validation = submitDetails(username, password);
            Assert.AreEqual(validation.Text, "You logged into a secure area!");
            Assert.Pass();
        }

        //This test that checks the username is right... 
        // SHOULD NOT EXIST as usernames should not be exposed. 
        [TestCase ("", "")]
        [TestCase ("NOTtomsmith", "")]
        public void InvalidUserNameTest(string username, string password)
        {     
            var validation = submitDetails(username, password);
            Assert.AreEqual(validation.Text, "Your username is invalid!");
        }

        [TestCase ("tomsmith", "")]
        public void InvalidPasswordTest(string username, string password)
        {     
            var validation = submitDetails(username, password);
            Assert.AreEqual(validation.Text, "Your password is invalid!");
        }

        private IWebElement submitDetails(string username, string password) {
            driver.FindElement(By.Id("username")).SendKeys(username);
            Thread.Sleep(SleepTime);
            driver.FindElement(By.Id("password")).SendKeys(password);
            Thread.Sleep(SleepTime);
            
            driver.FindElement(By.ClassName("radius")).Click();
            Thread.Sleep(SleepTime);

            return driver.FindElement(By.Id("flash"));
        }


        [OneTimeTearDown]
        public void Close() 
        {
            driver.Close();
        }
    }
}