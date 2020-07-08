using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestTask
{

    [Binding]
    public class GeneralSteps
    {
        private readonly ChromeDriver driver;
        private ScenarioContext scenarioContext;
        public GeneralSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = scenarioContext.Get<ChromeDriver>("currentDriver");
        }

        public void ClickTheButtonByAttributeValue(string buttonName, string atribute, string atrributeValue)
        {
            var button = driver.FindElement(HelperFactory.SelectorByAttributeValue(atribute, atrributeValue));
            button.Click();
        }
        public bool CheckIfElementContainsText(string text, string selector)
        {
            var WebDriverExtensions = new WebDriverExtensions(driver);
            var element = WebDriverExtensions.FindElement(By.CssSelector(selector));
            string elementInnerText = element.GetAttribute("innerText").ToString();
            bool IsElementContainText = elementInnerText.Equals(text);
            Assert.That(IsElementContainText, "Not Equal to " + elementInnerText);
            return IsElementContainText;
        }
        public void EnterTextIntoTextField(string text, string textFieldName, string atribute, string atrributeValue)
        {
            var WebDriverExtensions = new WebDriverExtensions(driver);
            var textField = WebDriverExtensions.FindElement(HelperFactory.SelectorByAttributeValue(atribute, atrributeValue));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            textField.SendKeys(text);
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
