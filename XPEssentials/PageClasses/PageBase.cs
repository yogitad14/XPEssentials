using OpenQA.Selenium;

namespace XPEssentials.PageClasses
{
    public class PageBase : BaseClass
    {
        protected readonly IWebDriver _driver;
        protected readonly int _defaultWaitTime=30;
        public Action actions;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
            actions = new Action(_driver, _defaultWaitTime);
        }
    }
}
