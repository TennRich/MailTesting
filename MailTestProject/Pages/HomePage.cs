using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace MailTestProject
{
    class HomePage
    {
        public IWebDriver driver;

        [FindsBy(How = How.Id, Using = "PH_user-email")]
        private IWebElement loggedInUser;

        [FindsBy(How = How.Id, Using = "mailbox:write_letter")]
        private IWebElement newLetter;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsLoggedIn(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(4000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("PH_user-email")));

            if (loggedInUser.Text.Contains(ConfigurationManager.AppSettings["username"]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateNewLetter()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(4000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("mailbox:write_letter")));
            newLetter.Click();
        }
    }
}
