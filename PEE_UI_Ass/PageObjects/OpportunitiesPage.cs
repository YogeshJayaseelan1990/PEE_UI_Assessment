using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PEI_UI_Ass.PageObjects
{
    public class OpportunitiesPage
    {
        IWebDriver driver;

        public OpportunitiesPage(IWebDriver driver)
        {
            this.driver = driver;
            SeleniumExtras.PageObjects.PageFactory.InitElements(driver, this);
        }

        //New Opportunity Button Element
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'New')]")]
        private IWebElement newButton;
      

        public OpportunitiesPage ClikNewOpportunity()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
            wait.Until(driver => newButton.Displayed);
            newButton.Click(); ;

            Console.WriteLine("New Opportunity button is Clicked");
            return new OpportunitiesPage(driver);

        }
    }
}