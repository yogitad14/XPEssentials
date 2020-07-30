using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using XPEssentials.PageClasses;

namespace XPEssentials.Tests
{
    public class UnitTests : TestBase
    {
        [Test]
        [Ignore("failing")]
        public void NavigateToArchievedNewsLetterTest()
        {
            driver.Navigate().GoToUrl("https://www.automation.com/");

            AutomationHomePage homePage = new AutomationHomePage(driver);

            IndustriesPage industriesPage = homePage.NavigateToIndustriesPage();
            BuildingAutomationPage buildingAutomationPage = industriesPage.NavigateToBuildingAutomationPage();
            ArchieveNewsLettersPage newsLettersPage = buildingAutomationPage.NavigateToNewsLetterArchievePage();

            List<IWebElement> archievedNewsLettersList = newsLettersPage.getListofArchievedNewsLetters();
            newsLettersPage.PrintLinks(archievedNewsLettersList);

            Console.WriteLine("Navigation Path is : {0}", driver.Url.ToString());
        }

        [Test]
        [Ignore("failing")]
        public void ProductsPageNavigationTest()
        {
            string keyword = "weidmuller";
            string category = "Components / Terminal Blocks";
            driver.Navigate().GoToUrl("https://www.automation.com/");

            AutomationHomePage homePage = new AutomationHomePage(driver);

            ProductSearchPage productSearchPage = homePage.NavigateToSearchPage();

            string productSearchPageTitle = homePage.GetProductPageTitle();

            productSearchPage.SearchForProducts(keyword, string.Empty);

            bool isKeywordPresent = productSearchPage.CheckForKeywordInProductLinks();

            productSearchPage.ClickOpenSearchButton();
            productSearchPage.SearchForProducts(string.Empty, category);

            string categoryDisplayed = productSearchPage.GetProductCategory();
            string firstProductLinkText = productSearchPage.GetFirstProductLinkText();

            ProductDetailsPage productDetailsPage = productSearchPage.NavigateToProductDetailsPage();
            string productDetailsPageHeading = productDetailsPage.GetProductDetailsPageHeading();
            productDetailsPage.NavigateToPreviousPage();
            string NewfirstProductLinkText = productSearchPage.GetFirstProductLinkText();

            Console.WriteLine("String list contains keyword : {0}", isKeywordPresent);
            Console.WriteLine("Category searched matches Product Catogory displayed : {0}", category.Contains(categoryDisplayed));

            Assert.AreEqual(firstProductLinkText, productDetailsPageHeading);
            Assert.AreEqual(firstProductLinkText, NewfirstProductLinkText);
            Assert.AreEqual("Product Search - Automation, Control & Instrumentation Products", productSearchPageTitle);
        }

        [Test]
        public void SalarySurveyResultsTest()
        {
            string RegionOfWorld = "South Asia";
            string RegionOfUnitedStates = "West South Central (South)";
            driver.Navigate().GoToUrl("https://www.automation.com/");

            AutomationHomePage homePage = new AutomationHomePage(driver);

            SalarySurveyResultsPage salarySurveyResults = homePage.NavigateToSalarySurveyResultsPge();

            string averageSalary = salarySurveyResults.GetAverageSalaryForRegionOfWorlds(RegionOfWorld);
            string percentRespondents = salarySurveyResults.GetAverageSalaryForRegionOfUS(RegionOfUnitedStates);

            Console.WriteLine("Average salary : {0}", averageSalary);
            Console.WriteLine("Percent Respondents : {0}", percentRespondents);

        }



        /// <summary>
        /// test to check failure reflected in extentreport
        /// </summary>
        [Test]
        public void testforSuccess()
        {
            Assert.AreEqual("string1", "string1");
        }

        [Test]
        public void TestClickGoogleSignInButton()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

            IWebElement element = driver.FindElement(By.Id("gb_70"));
            element.Click();
        }

        // 2.Search on Google page
        [Test]
        public void TestSearchOnGoogle()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://www.google.com");

            IWebElement searchElement = driver.FindElement(By.Name("q"));
            searchElement.SendKeys("Selenium tutorial");
            searchElement.SendKeys(Keys.Enter);
        }

    }
}
