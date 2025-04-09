using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Reflection;

namespace PEI_UI_Ass.Baseclass
{
    public class BaseTest
    {


        public IWebDriver? driver;

        //Assume the Below url is the Dynamics 365 Login
        //Note : As we canot login with personal microsoft account with D365
        //and domain name is mandatory. We are using the sample test applciation
        public String D365Url = "https://org10da1532.crm8.dynamics.com/main.aspx?appid=83431a7e-8c09-f011-bae4-000d3aca1dff&pagetype=dashboard&id=eaa6e6bb-4712-ec11-b6e7-00224820f09b&type=system&_canOverride=true";



        [SetUp]
        public void StartBrowser()
        {
            //Geting the Browser input from the App.config file
            string browserName = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["browser"].Value;

            Console.WriteLine("The Borwser Used in the Configurations file is  " + browserName);
            InitBrowser(browserName);
            //Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            //Maximize Driver
            driver.Manage().Window.Maximize();

        }

        //Method to Initiate Different Browser using Switch Case
        private void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":

                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--incognito");
                    chromeOptions.AddArgument("--no-sandbox");
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "Edge":

                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--incognito");
                    edgeOptions.AddArgument("--no-sandbox");
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    ChromeOptions chromeOptions1 = new ChromeOptions();
                    chromeOptions1.AddArgument("--incognito");
                    chromeOptions1.AddArgument("--no-sandbox");
                    driver = new ChromeDriver(chromeOptions1);
                    break;
            }

        }

        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TestContext.AddTestAttachment(Screenshot("Failed"));
            }
            else
            {
                TestContext.AddTestAttachment(Screenshot("Passed"));
            }
            driver.Quit();
            driver.Dispose();

        }

        //Method to Take Screenshot
        private string Screenshot(string name)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = TestContext.CurrentContext.Test.Name + name + ".png";
            ss.SaveAsFile(path);
            return path;
        }
    }
}