using OpenQA.Selenium;

namespace XPEssentials.PageClasses
{
    public class IndustriesPage : PageBase
    {
        #region locators
        private By _buildingAutomation = By.LinkText("Building Automation");
        #endregion

        public IndustriesPage(IWebDriver driver) : base(driver)
        {
        }

        public BuildingAutomationPage NavigateToBuildingAutomationPage()
        {
            actions.Click(_buildingAutomation);
            return new BuildingAutomationPage(_driver);
        }
    }
}