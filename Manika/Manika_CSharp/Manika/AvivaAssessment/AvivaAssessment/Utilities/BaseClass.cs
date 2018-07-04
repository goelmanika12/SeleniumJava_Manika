using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using OpenQA.Selenium.IE;

namespace AvivaAssessment
{

    public class BaseClass
    {

        public static void LaunchBrowser(IWebDriver driver)
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }

        public static void closeBrowser(IWebDriver driver)
        {
            driver.Close();
        }

        public static void TakeScreenshotMethod(IWebDriver driver)
        {

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }

        public static void ExplicitWait(IWebDriver driver, IWebElement element, int time)
        {
            //Explicit wait time for the element to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

    }
}
