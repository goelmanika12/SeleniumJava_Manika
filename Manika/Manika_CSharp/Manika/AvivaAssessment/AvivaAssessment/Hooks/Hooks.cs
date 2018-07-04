using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AvivaAssessment.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            _driver = InitializeBrowser(_driver, "Chrome");
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterStep]
        public void ScreenshotMethod()
        {
            BaseClass.TakeScreenshotMethod(_driver);
        }

        [AfterScenario]
        public void closeScenario()
        {
            BaseClass.closeBrowser(_driver);
        }

        //Initializing the browser        
        public static IWebDriver InitializeBrowser(IWebDriver driver, String browser)
        {
            if (browser == "Chrome")
            {
                driver = new ChromeDriver();
            }

            else if (browser == "IE")
            {
                driver = new InternetExplorerDriver();
            }
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
