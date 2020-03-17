using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace TestTask
{

    [Binding]
    public class FeatureSteps : GeneralSteps
    {
        private ChromeDriver driver;
        private ScenarioContext scenarioContext;

        public FeatureSteps(ScenarioContext scenarioContext1) : base(scenarioContext1)
        {
            this.scenarioContext = scenarioContext1;
            driver = scenarioContext.Get<ChromeDriver>("currentDriver");

        }


        [Given("I have entered username")]
        [When("I have entered username")]
        public void GivenIEnteredUsername()
        {
            var signInButton = driver.FindElement(HelperFactory.SelectorByAttributeValue("data-qa", "signin-link"));
            signInButton.Click();
            var WebDriverExtensions = new WebDriverExtensions(scenarioContext);
            var element = WebDriverExtensions.FindElement(By.CssSelector("h1.h2.h4--desktop"), 10);
            string el1 = element.GetAttribute("innerText").ToString();
            string pageH1Element = "Sign In to Zyro";
            Assert.That(el1.Equals(pageH1Element), "Not Equal to " + el1);

            var emailAddress = driver.FindElement(HelperFactory.SelectorByAttributeValue("data-qa", "signin-inputfield-emailaddress"));
            System.Threading.Thread.Sleep(1000);
            emailAddress.SendKeys("neringa.g@mailinator.com");
            var password = driver.FindElement(HelperFactory.SelectorByAttributeValue("id", "password"));
            password.SendKeys("testas123");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            var submitButton = driver.FindElement(HelperFactory.SelectorByAttributeValue("data-qa", "auth-submit-button"));
            submitButton.Click();
            var element1 = WebDriverExtensions.FindElement(By.CssSelector("h2.welcome__title.h1.h3--desktop "));
            string el2 = element1.GetAttribute("innerText").ToString();
            string pageH1Element1 = "Let’s create your first website";
            Assert.That(el2.Equals(pageH1Element1), "Not Equal to " + el2);
        }
    //    public IWebElement WaitUntilElementExists(By elementLocator, int timeout = 10)
     //   {
         //   try
         //   {
         //       var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
         //       return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
         //   }
          //  catch (NoSuchElementException)
          //  {
         // / / /    Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            //    throw;
          //  }
           // catch (StaleElementReferenceException)
          //  {
          //      Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
           //     throw;
           // }
       // }
    }
}
