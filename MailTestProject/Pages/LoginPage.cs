using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace MailTestProject
{
    class LoginPage
    {
        public IWebDriver driver;

        [FindsBy(How = How.Id, Using = "mailbox:login")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "mailbox:password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "mailbox:submit")]
        private IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseurl"]);
        }

        public void FillUsernameField(string username)
        {
            inputLogin.SendKeys(username);
        }

        public void FillPasswordField(string password)
        {
            inputPassword.SendKeys(password);
        }


        public void ClickButtonToLogIn()
        {
            loginButton.Click();
        }

    }
}
