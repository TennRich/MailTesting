using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MailTestProject
{
    [TestFixture]
    public class MailTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = BrowserInstance.GetInstance(ConfigurationManager.AppSettings["browser"], driver);
        }

        [Test]
        public void IsLoggedIn()
        {
            Steps step = new Steps();
            step.LoginMail(driver);
            Assert.IsTrue(step.IsLoggedInUser(driver));
        }
        /// <summary>
        /// If test IsLoggedIn unnecessury, I can move Login logic to setup (from IsLetterSent test)
        /// </summary>
        [Test]
        public void IsLetterSent()
        {
            Steps step = new Steps();
            step.LoginMail(driver);
            if (step.IsLoggedInUser(driver))
            {
                step.FillAndSendLetter(driver);
            }
            Assert.IsTrue(step.IsLetterSent(driver));
        }


        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            driver = null;
        }
    }
}
