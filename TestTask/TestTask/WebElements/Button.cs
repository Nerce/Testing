using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml.XPath;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace TestTask.WebElements
{
    public class Button
    {
        private ChromeDriver driver;

        public Button(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void ClickTheButtonByAttributeValue(string atribute, string atrributeValue)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable
                (driver.FindElement(HelperFactory.SelectorByAttributeValue(atribute, atrributeValue)))).Click();
        }
    }
}
