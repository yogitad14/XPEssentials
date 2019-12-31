using OpenQA.Selenium;

namespace XPEssentials.PageClasses
{
    public class ProductDetailsPage : PageBase
    {
        #region locators
        private By _productHeading = By.CssSelector("#content > div > div:nth-child(2) > div.title-block h1");
        #endregion

        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetProductDetailsPageHeading()
        {
            return actions.Text(_productHeading);
        }

        public void NavigateToPreviousPage()
        {
            actions.NavigateBack();
        }
    }
}