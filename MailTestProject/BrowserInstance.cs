using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace MailTestProject
{
    class BrowserInstance
    {
        public static IWebDriver GetInstance(string appSetting, IWebDriver driver)
        {
            switch (appSetting)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
