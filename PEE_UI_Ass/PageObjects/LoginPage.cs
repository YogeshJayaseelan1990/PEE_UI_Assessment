using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PEI_UI_Ass.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PEI_UI_Ass.PagesObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            SeleniumExtras.PageObjects.PageFactory.InitElements(driver, this);
        }

        //UserName Element
        [FindsBy(How=How.XPath, Using = "//input[@name='user-name']")]
        private IWebElement username;

        //Password Element
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement password;

        //Login Element
        [FindsBy(How = How.XPath, Using = "//input[@name='login-button']")]
        private IWebElement loginButton;

        //Method to Type on the suer name field 
        public LoginPage TypeUserName(string UserName)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => username.Displayed);
            username.SendKeys(UserName);
            return this;
          
        }

        //Method to Type on the Password Field 
        public LoginPage TypePassword(string Password)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => password.Displayed);
            password.SendKeys(Password);
            return this;

        }

        //Method to click on the Login Button
        public Homepage ClickLoginBtn()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => loginButton.Displayed);
            loginButton.Click(); ;

            Console.WriteLine("The login is successfull ");
            return new Homepage(driver);

        }
    }
}
