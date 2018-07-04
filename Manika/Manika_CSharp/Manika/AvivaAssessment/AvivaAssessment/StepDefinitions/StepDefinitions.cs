using AvivaAssessment.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AvivaAssessment.StepDefinitions
{
    [Binding]
    class StepDefinitions
    {

        GoogleSearchPageObject GPage;
        ResultsPageObject RPage;
        private IWebDriver driver;
        public StepDefinitions(IWebDriver _driver)
        {
            driver = _driver;
            GPage = new GoogleSearchPageObject(_driver);
            RPage = new ResultsPageObject(_driver);
        }


        [Given(@"launch the google home page")]
        public void GivenLaunchTheGoogleHomePage()
        {
            BaseClass.LaunchBrowser(driver);
        }

        [Given(@"search with the string '(.*)'")]
        public void GivenSearchWithTheString(string keyword)
        {
            GPage.SearchGoogleHomePage(keyword);
        }

        [When(@"click on search button")]
        public void WhenClickOnSearchButton()
        {
            GPage.clickEnterButton();
        }

        [Then(@"prints the (.*)th link text of results page\.")]
        public void ThenPrintsTheThLinkTextOfResultsPage_(int linkNumber)
        {
            RPage.LinkText(5);
        }

        [Then(@"number of links should be (.*)")]
        public void ThenNumberOfLinksShouldBe(int count)
        {
            RPage.LinksCount(count);
        }


        [When(@"I click on Aviva link and login button without providing credentials")]
        public void WhenIClickOnAvivaLinkAndLoginButtonWithoutProvidingCredentials()
        {
            RPage.AvivaLoginPage();
            //Explicit wait time for the element to be clickable
            BaseClass.ExplicitWait(driver, RPage.LoginButton, 10);
            RPage.InvalidLogin();
        }

        [Then(@"the result should be the error message display")]
        public void ThenTheResultShouldBeTheErrorMessageDisplay()
        {
            RPage.ErrorMessage();
        }

    }
}
