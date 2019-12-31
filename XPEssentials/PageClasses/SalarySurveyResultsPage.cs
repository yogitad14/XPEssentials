using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace XPEssentials.PageClasses
{
    public class SalarySurveyResultsPage : PageBase
    {
        private By _regionOfWorldTable = By.XPath("//*[@id='content']/div/div[4]/table[2]");
        private By _regionOfUSTable = By.XPath("//*[@id='content']/div/div[4]/table[3]");
        private By _regionOfWorld = By.CssSelector("td:nth-child(1)");
        private By _averageSalary = By.CssSelector("td:nth-child(2)");
        private By _percentRespondents = By.CssSelector("td:nth-child(3)");
        private By _row = By.TagName("tr");

        public SalarySurveyResultsPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetAverageSalaryForRegionOfWorlds(string regionOfWorld)
        {
            IWebElement regionOfWorldTable = _driver.FindElement(_regionOfWorldTable);
            List<IWebElement> regionOfWorldTableRows = regionOfWorldTable.FindElements(_row).ToList();

            string averageSalary = regionOfWorldTableRows
                                    .Where(x => (x.FindElement(_regionOfWorld).Text).Trim().Equals(regionOfWorld))
                                    .Select(r => r.FindElement(_averageSalary).Text).FirstOrDefault();

            return averageSalary;
        }

        public string GetAverageSalaryForRegionOfUS(string regionOfUnitedStates)
        {
            IWebElement regionOfUSTable = _driver.FindElement(_regionOfUSTable);
            List<IWebElement> regionOfUSTableRows = regionOfUSTable.FindElements(_row).ToList();

            string percentRespondents = regionOfUSTableRows
                                            .Where(x => (x.FindElement(_regionOfWorld).Text).Trim().Equals(regionOfUnitedStates))
                                            .Select(r => r.FindElement(_percentRespondents).Text).FirstOrDefault();
            return percentRespondents;
        }
    }
}