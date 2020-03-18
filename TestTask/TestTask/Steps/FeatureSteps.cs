using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace TestTask
{

    [Binding]
    public class FeatureSteps : GeneralSteps
    {
        private ChromeDriver driver;
        private ScenarioContext scenarioContext;

        public FeatureSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = scenarioContext.Get<ChromeDriver>("currentDriver");

        }
        [When("I press Sign In Button")]
        public void PressSignInButton()
        {
            ClickTheButtonByAttributeValue("Sign In", "data-qa", "signin-link");
            CheckIfElementContainsText("Sign In to Zyro", "h1.h2.h4--desktop");
        }

        [When("I enter email")]
        public void EnterEmail()
        {
            User u = new User();
            u.FillInWithUserData();
            EnterTextIntoTextField(u.Email, "Email Address", "data-qa", "signin-inputfield-emailaddress");
            //      var WebDriverExtensions = new WebDriverExtensions(scenarioContext);
            //    if (IsElementPresent(By.ClassName("button-close__container")))
            //    {

            //       ClickTheButtonByAttributeValue(String.Empty, "class", "button-close__container");
            //      ClickTheButtonByAttributeValue(String.Empty, "class", "button-close__container");
            //  }

        }
        [When("I enter password")]
        public void EnterPassword()
        {
            User u = new User();
            u.FillInWithUserData();
            EnterTextIntoTextField(u.Password, "Password", "id", "password");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }
        [When("I press Submit button")]
        public void PressSubmitButton()
        {
            ClickTheButtonByAttributeValue("Submit", "data-qa", "auth-submit-button");
        }

        [When("I see user profile")]
        public void UserProfileVisible()
        {
            CheckIfElementContainsText("You don't have any websites yet. Click Get Started to create your first website.", "h5");
            Actions action = new Actions(driver);
            var element = driver.FindElement(HelperFactory.SelectorByAttributeValue("data-qa", "popupwindow-icon-userprofile"));
            action.MoveToElement(element).Perform();
            bool elementPresent = IsElementPresent(HelperFactory.SelectorByAttributeValue("class", "user-name"));
            Assert.IsTrue(elementPresent);
        }
        [When("I press Log Out button")]
        public void UserLoggedOut()
        {
            Actions action = new Actions(driver);
            var element = driver.FindElement(HelperFactory.SelectorByAttributeValue("data-qa", "popupwindow-icon-userprofile"));
            action.MoveToElement(element).Perform();
            ClickTheButtonByAttributeValue(String.Empty, "data-qa", "popupwindow-link-logout");
        }

        [Then("I don't see user profile")]
        public void UserProfileNotVisible()
        {
            //   System.Threading.Thread.Sleep(5000);
            bool elementPresent = IsElementPresent(HelperFactory.SelectorByAttributeValue("data-qa", "signin-link"));
            Assert.IsTrue(elementPresent);
        }
    }
}
