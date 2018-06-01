using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace MailTestProject
{
    class CreateLetterPage
    {
        public IWebDriver driver;
        WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//textarea[@data-original-name='To']")]
        private IWebElement composeTo;

        [FindsBy(How = How.XPath, Using = "//input[@name='Subject']")]
        private IWebElement subject;

        [FindsBy(How = How.XPath, Using = "//*[@data-name = 'send']")]
        private IWebElement sendLetterButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'message-sent__title') and text()=' отправлено. ']")]
        private IWebElement resultMessage;

        public CreateLetterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(4000));
        }

        public void FillEmail()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@data-original-name='To']")));
            composeTo.SendKeys(ConfigurationManager.AppSettings["username"] + "@mail.ru");
        }

        public void FillSubject()
        {
            subject.SendKeys(ConfigurationManager.AppSettings["subject"]);
        }

        public void FillBody()
        {
            Actions action = new Actions(driver);
            action.SendKeys(Keys.Tab).SendKeys(ConfigurationManager.AppSettings["text"]).Perform();
        }

        public void SendLetter()
        {
            sendLetterButton.Click();
        }

        public bool GetResultMessage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class, 'message-sent__title') and text()=' отправлено. ']")));
            if (resultMessage.Text.Contains("Ваше письмо отправлено.")) return true;
            else return false;
        }
    }
}
