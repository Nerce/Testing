using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestTask.Helpers
{
    public class ElementLoading
    {
        private ChromeDriver driver;

        public ElementLoading(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void waitUntilElementIsLoaded(int waitSeconds, string attributeName, string attribute)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(HelperFactory.SelectorByAttributeValue(attributeName, attribute)));
        }
    }
}
