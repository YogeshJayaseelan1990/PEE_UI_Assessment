using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PEI_UI_Ass.PageObjects
{
    public class Homepage
    {
        IWebDriver driver;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            SeleniumExtras.PageObjects.PageFactory.InitElements(driver, this);
        }

        //Homepage Header Element
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Sales dashboard')]")]
        private IWebElement headerElement;

        //Oppoprtunites Element 
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Opportunities')]")]
        private IWebElement opportunities;
        

        //Method to get the Title of the Homepage after performing login
        public Homepage GetHomePageHeader()
        {
            String OriginalTitle = "Sales dashboard";
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => headerElement.Displayed);
            String ActualTitle = headerElement.Text;
            if(ActualTitle == OriginalTitle)
            {
                Console.WriteLine("The Original Title matches with the Actual Title       "   + "Original Title = " + OriginalTitle + "Actual Title = " + ActualTitle);
            }
            else
            {
                Console.WriteLine("The Original Title does not match with the Actual Title      " + "Original Title = " + OriginalTitle + "Actual Title = " + ActualTitle);
            }

            return this;

        }

        public OpportunitiesPage ClikOpportunities()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => opportunities.Displayed);
            opportunities.Click(); ;

            Console.WriteLine("Opportunities Menu is Clicked SignIn");
            return new OpportunitiesPage(driver);

        }
    }
}