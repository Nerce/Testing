using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using TestTask;

namespace TestTask
{

    [Binding]
    public class GeneralSteps
    {
        private readonly ChromeDriver driver = new ChromeDriver();
        private ScenarioContext scenarioContext;
        public GeneralSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = scenarioContext.Get<ChromeDriver>("currentDriver");
        }

        [When(@"I Log In")]

        public void LoginToTheSystem()
        {
            var tab = driver.FindElement(HelperFactory.SelectorByAttributeValue("title", "a"));
            tab.SendKeys("aaaaaa");
            TimeSpan.FromSeconds(10);
              driver.Quit();

            //  var loginSteps = new LoginSteps();
            //    loginSteps.GivenIEnteredUsername("a");
            //    loginSteps.GivenIEnterPassword("a");
            //   loginSteps.WhenIPressLogin();
        }

        [When(@"I navigate to (.*) tab")]
        public void WhenINavigateToTab(string tabName)
        {
            var tab = driver.FindElement(HelperFactory.SelectorByAttributeValue("title", tabName));
            Assert.IsTrue(tab.Displayed);
            tab.Click();
        }

        [Then(@"I should see (.*) grid")]
        public void WhenISeeGrid(string gridName)
        {
            var grid = driver.FindElement(HelperFactory.SelectorByAttributeValue("role", "grid"));
            Assert.IsTrue(grid.Displayed);
            grid.Click();
        }

        [When(@"I click on the (.*) tab")]

        public void WhenIGoToTheTab(string tabText)
        {
            var tab = driver.FindElement(By.LinkText(tabText));
            tab.Click();
        }

        [When(@"I go into (.*) details")]

        public void WhenIGoIntoDetails(string name)
        {
            var gridRow = driver.FindElement(By.XPath("//tr[@data-kendo-grid-item-index=\"0\"]"));
            var ac = new Actions(driver);

            ac.DoubleClick(gridRow).Perform();
        }
    }
}
