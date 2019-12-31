using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace XPEssentials.PageClasses
{
    public class ProductSearchPage : PageBase
    {
        #region locators
        private By _searchKeyword = By.Name("text_search_1_707");
        private By _searchButton = By.XPath("//div[@class='search-button']/a");
        private By _categoryList = By.XPath("//input[@class='select2-search__field']");
        private By _openSearchLink = By.XPath("//a[@class='toggle-search']");
        private By _pageContainer = By.CssSelector("#pagination-container");
        private By _navigationLinks = By.XPath("//div[@class='text-holder']/h2");
        private By _firstProductLink = By.CssSelector("#pagination-container > div:nth-child(1) .text-holder a");
        private By _productCategory = By.CssSelector("div .posted-info a");
        #endregion

        public ProductSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchForProducts(string keyword, string Category)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                actions.SendKeys(_searchKeyword,keyword);
            }

            if (!string.IsNullOrEmpty(Category))
            {
                actions.Click(_categoryList);
                actions.Click(By.XPath("//li[contains(text(), " + "'" + Category + "'" + ")]"));
            }

            actions.Click(_searchButton);
        }

        public bool CheckForKeywordInProductLinks()
        {
            IWebElement pageLocator = _driver.FindElement(_pageContainer);
            List<string> listOfBlockHeadings = pageLocator.FindElements(_navigationLinks).Select(x => x.Text).ToList();
            return listOfBlockHeadings.TrueForAll(ContainsKeyword);
        }

        public string GetProductCategory()
        {
            return actions.Text(_productCategory);
        }

        public string GetFirstProductLinkText()
        {
           return actions.Text(_firstProductLink);
        }

        public ProductDetailsPage NavigateToProductDetailsPage()
        {
            actions.Click(_firstProductLink);
            return new ProductDetailsPage(_driver);
        }

        public void ClickOpenSearchButton()
        {
            actions.Click(_openSearchLink);
        }

        private bool ContainsKeyword(string obj)
        {
            return obj.ToLower().Contains("weidmuller");
        }
    }
}