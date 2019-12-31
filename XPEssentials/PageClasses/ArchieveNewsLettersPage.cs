using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XPEssentials.PageClasses
{
    public class ArchieveNewsLettersPage : PageBase
    {
        #region locators
        private By _pageLinks = By.XPath("//*[@id='content']/div/div[4]");
        private By _newsLetterlinks = By.TagName("a");
        #endregion

        public ArchieveNewsLettersPage(IWebDriver driver) : base(driver)
        {
        }

        public List<IWebElement> getListofArchievedNewsLetters()
        {
            IWebElement element = _driver.FindElement(_pageLinks);
            return element.FindElements(_newsLetterlinks).ToList();
        }

        public void PrintLinks(List<IWebElement> allLinkElements)
        {
            int linkCount = allLinkElements.Count();

            Console.WriteLine("Number of total links : {0}", linkCount);

            for (int i = 0; i <= linkCount - 1; i++)
            {
                Console.WriteLine("Link {0} : {1}", i + 1, allLinkElements[i].Text);
            }
        }
    }
}