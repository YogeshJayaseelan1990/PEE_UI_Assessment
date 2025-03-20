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
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Swag Labs')]")]
        private IWebElement headerElement;

        //Method to get the Title of the Homepage after performing login
        public Homepage GetHomePageHeader()
        {
            String OriginalTitle = "Swag Labs";
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => headerElement.Displayed);
            String GetTitle = headerElement.Text;
            if(GetTitle == OriginalTitle)
            {
                Console.WriteLine("The Original Title matches with the Actual Title ");
            }
            else
            {
                Console.WriteLine("The Original Title does not match with the Actual Title ");
            }

            return this;

        }
    }
}