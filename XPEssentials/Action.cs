using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace XPEssentials
{
    public class Action
    {
        private readonly IWebDriver _driver;
        private readonly int _defaultWaitTime;

        public Action(IWebDriver driver, int defaultTime)
        {
                _driver = driver;
                _defaultWaitTime = defaultTime;
        }

        /// <summary>
        /// Wait until the element with the given text is visible on the page.
        /// </summary>
        public void WaitUntilElementIsVisible(By locator)
        {
            WebDriverWait wait = GetWebDriverWait();
            wait.Until(_driver => _driver.FindElement(locator).Displayed);
        }

        /// <summary>
        /// Get an element by its locator, e.g. Id.
        /// </summary>
        private IWebElement FindElement(By locator)
        {
            WaitUntilElementIsVisible(locator);
            return _driver.FindElement(locator);
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns></returns>
        private ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            WaitUntilElementIsVisible(locator);
            return _driver.FindElements(locator);
        }

        /// <summary>
        /// Creats Webdriverwait instance 
        /// </summary>
        /// <returns></returns>
        private WebDriverWait GetWebDriverWait()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_defaultWaitTime));
            return wait;
        }

        /// <summary>
        /// Click the given element.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <param name="index">The index.</param>
        public void Click(By locator, int index = 0)
        {
            var element = FindElementAfterWaitingForClickability(locator, index);
            element.Click();
        }

        /// <summary>
        /// Finds the element after waiting for clickability.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public IWebElement FindElementAfterWaitingForClickability(By locator, int index = 0)
        {
            WaitUntilElementClickable(locator);
            return _driver.FindElements(locator)[index];
        }

        /// <summary>
        /// Send the given text to the given element.
        /// </summary>
        public void SendKeys(By locator, string text, int index = 0)
        {
            List<IWebElement> elements = FindElementsAfterWaitingForClickability(locator);
            elements[index].Clear();
            elements[index].SendKeys(text);
        }

        /// <summary>
        /// Finds the element after waiting for clickability.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns></returns>
        private List<IWebElement> FindElementsAfterWaitingForClickability(By locator)
        {
            WaitUntilElementClickable(locator);

            var elements = _driver.FindElements(locator);
            var visibleElements = (from item in elements
                                   where item.Displayed.Equals(true) && item.Enabled.Equals(true)
                                   select item).ToList();
            return visibleElements;
        }

        /// <summary>
        /// Wait until the given element is clickable.
        /// </summary>
        public void WaitUntilElementClickable(By locator)
        {
            WebDriverWait wait = GetWebDriverWait();
            wait.Until(_driver => _driver.FindElement(locator).Displayed && _driver.FindElement(locator).Enabled);
            wait.Until(_driver => _driver.FindElement(locator).Location.Equals(_driver.FindElement(locator).Location));
        }
        
        /// <summary>
        /// Get the text of a given element.
        /// </summary>
        public string Text(By locator, int index = 0)
        {
            var element = FindElements(locator)[index];
            return element.Text.Trim();
        }

        /// <summary>
        /// Gets the elements count.
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns></returns>
        public int GetElementsCount(By locator)
        {
            return FindElements(locator).Count();
        }

        /// <summary>
        /// Check if the elements are clickable
        /// </summary>
        /// <param name="locator">The locator.</param>
        /// <returns></returns>
        public List<IWebElement> GetElements(By locator)
        {
            List<IWebElement> elements = FindElements(locator).ToList();
            return elements;
        }

        /// <summary>
        /// Navigate back to previous tab of browser.
        /// </summary>
        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }

        public virtual void MoveToElementAndClick(By locator1, By locator2)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(FindElement(locator1)).Perform();
            action.MoveToElement(FindElement(locator2)).Click().Perform();
        }
    }
}
