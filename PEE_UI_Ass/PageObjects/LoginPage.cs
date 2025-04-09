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

        //Email Element
        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        private IWebElement email;

        //NextButton Element
        [FindsBy(How = How.XPath, Using = "//input[@value='Next']")]
        private IWebElement next;
    
        //Password Element
        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement password;

        //Signin Element
        [FindsBy(How = How.XPath, Using = "//input[@value='Sign in']")]
        private IWebElement signInButton;

        //YesButton Element
        [FindsBy(How = How.XPath, Using = "//input[@value='Yes']")]
        private IWebElement yesButton;

        //Method to Type on the Email field 
        public LoginPage TypeEmail(string UserName)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => email.Displayed);
            email.SendKeys(UserName);
            return this;
          
        }


        //Method to Click on the Next button
        public LoginPage ClickNextButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => next.Displayed);
            next.Click();
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

        //Method to click on the SiginIn Button
        public LoginPage ClickSiginBtn()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => signInButton.Displayed);
            signInButton.Click(); ;
            return this;

        }

        public Homepage ClickYesBtn()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => yesButton.Displayed);
            yesButton.Click(); ;

            Console.WriteLine("The SignIn is successfull ");
            return new Homepage(driver);

        }
    }
}
