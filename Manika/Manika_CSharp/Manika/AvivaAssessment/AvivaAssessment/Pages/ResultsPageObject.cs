
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AvivaAssessment.Pages
{
    class ResultsPageObject
    {
        private IWebDriver driver;
        public ResultsPageObject(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//h3/a")]
        public IList<IWebElement> totallinks { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://online.avivaindia.com/']")]
        public IWebElement AvivaLoginLink { get; set; }

        [FindsBy(How = How.Id, Using = "lnkLogin")]
        public IWebElement LoginButton { get; set; }

        //Positive Scenario
        int totallinkscount;

        public void LinkText(int linknumber)
        {
            //Prints the fifth link text of Results page of Aviva
            Console.WriteLine("Link text of 5 th link is:" + totallinks.ElementAt(linknumber).Text);
        }

        public void LinksCount(int count)
        {
            //Printing number of links returned on searching Aviva in Google home page
            totallinkscount = totallinks.Count;
            Console.WriteLine("Total number of links returned:" + totallinkscount);
            Console.WriteLine("Expected number of links returned :" + count);
            Assert.AreEqual(count, totallinkscount);
        }

        //Negative Scenario
        public void AvivaLoginPage()
        {
            AvivaLoginLink.Click();
        }
        
        public void InvalidLogin()
        {
            //Click on login button without providing credentials
            LoginButton.Click();
        }

        public void ErrorMessage()
        {
            //Error message displayed on clicking login button without providing credentials
            String text = driver.FindElement(By.Id("spnError")).Text;
            Console.WriteLine("Error Message displayed on clicking Login without providing credentials: "+text);
            Assert.AreEqual("Please fill in all 3 fields.", text);
        }
        
    }
}
