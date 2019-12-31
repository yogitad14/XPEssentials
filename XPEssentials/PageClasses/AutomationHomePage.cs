using OpenQA.Selenium;

namespace XPEssentials.PageClasses
{
    public class AutomationHomePage : PageBase
    {
        #region Locators
        private By _productLink = By.XPath("//*[@id='nav']/li[3]/a");
        private By _pageHeading = By.TagName("h1");
        private By _industries = By.ClassName("last-child-a");
        private By _jobLink = By.CssSelector("#nav > li:nth-child(4) > a");
        private By _dropDownOption = By.CssSelector("#nav > li:nth-child(4) > div > div > ul > li:nth-child(3) > a");
        #endregion

        public AutomationHomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetProductPageTitle()
        {
            return actions.Text(_pageHeading);
        }

        public IndustriesPage NavigateToIndustriesPage()
        {
            actions.Click(_industries);
            return new IndustriesPage(_driver);  
        }

        public ProductSearchPage NavigateToSearchPage()
        {
            actions.Click(_productLink);
            return new ProductSearchPage(_driver);
        }

        public SalarySurveyResultsPage NavigateToSalarySurveyResultsPge()
        {
            actions.MoveToElementAndClick(_jobLink, _dropDownOption);
            return new SalarySurveyResultsPage(_driver);
        }
    }
}
