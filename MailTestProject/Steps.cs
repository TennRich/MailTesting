using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTestProject
{
    class Steps
    {
        private readonly string Username = ConfigurationManager.AppSettings["username"];
        private readonly string Password = ConfigurationManager.AppSettings["password"];

        public void LoginMail(IWebDriver driver)
        {
            var loginPage = new LoginPage(driver);
            loginPage.OpenPage(driver);
            loginPage.FillUsernameField(Username);
            loginPage.FillPasswordField(Password);
            loginPage.ClickButtonToLogIn();
        }

        public bool IsLoggedInUser(IWebDriver driver)
        {
            var homePage = new HomePage(driver);
            return homePage.IsLoggedIn(driver);
        }

        public void CreateNewLetter(IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseurl"]);
            homePage.CreateNewLetter();
        }

        public void FillAndSendLetter(IWebDriver driver)
        {
            
            CreateNewLetter(driver);
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);
            createLetterPage.FillEmail();
            createLetterPage.FillSubject();
            createLetterPage.FillBody();
            createLetterPage.SendLetter();
        }

        public bool IsLetterSent(IWebDriver driver)
        {
            CreateLetterPage createLetterPage = new CreateLetterPage(driver);
            return createLetterPage.GetResultMessage();
        }
    }
}
