using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvivaAssessment.Pages
{
    class GoogleSearchPageObject
    {
        private IWebDriver driver;
        public GoogleSearchPageObject(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
        }
    
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement Searchbox { get; set; }

        
        //Enter the keyword 'Aviva' on Google Search bar
        public void SearchGoogleHomePage(string keyword)
        {
            Searchbox.SendKeys(keyword);
        }

        //Click on Enter button
        public void clickEnterButton()
        {
            Searchbox.SendKeys(Keys.Enter);
        }

    }
}
