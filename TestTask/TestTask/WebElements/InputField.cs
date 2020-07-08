using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml.XPath;
using TechTalk.SpecFlow;

namespace TestTask.WebElements
{

    public class InputField
    {

        private ChromeDriver driver;

        public InputField(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void EnterValueIntoInputFieldByAttributeValue(string attributeName, string attribute, string inputValue)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //   wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((HelperFactory.SelectorByAttributeValue(attributeName, attribute))));
            var inputField = driver.FindElement(HelperFactory.SelectorByAttributeValue(attributeName, attribute));
            inputField.Clear();
            inputField.SendKeys(inputValue);
        }
    }
}
