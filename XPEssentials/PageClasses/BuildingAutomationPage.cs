using OpenQA.Selenium;

namespace XPEssentials.PageClasses
{
    public class BuildingAutomationPage:PageBase
    {
        #region locators
        private By _ArchieveNewLetters = By.LinkText("Building Automation e-Newsletter Archive");
        #endregion

        public BuildingAutomationPage(IWebDriver driver):base(driver)
        {
        }

        public ArchieveNewsLettersPage NavigateToNewsLetterArchievePage()
        {
            actions.Click(_ArchieveNewLetters);
            return new ArchieveNewsLettersPage(_driver);
        }
    }
}