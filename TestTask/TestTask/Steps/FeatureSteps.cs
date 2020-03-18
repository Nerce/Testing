using OpenQA.Selenium;
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


        [Given("I sign in")]
        [When("I sign in")]
        public void SignIn()
        {
            ClickTheButtonByAttributeValue("Sign In", "data-qa", "signin-link");
            CheckIfElementContainsText("Sign In to Zyro", "h1.h2.h4--desktop");
            User u = new User();
            u.FillInWithUserData();
            EnterTextIntoTextField(u.Email, "Email Address", "data-qa", "signin-inputfield-emailaddress");
            EnterTextIntoTextField(u.Password, "Password", "id", "password");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            ClickTheButtonByAttributeValue("Submit", "data-qa", "auth-submit-button");
            var WebDriverExtensions = new WebDriverExtensions(scenarioContext);
            if (IsElementPresent(By.ClassName("button-close__container")))
            {

                ClickTheButtonByAttributeValue(String.Empty, "class", "button-close__container");
                ClickTheButtonByAttributeValue(String.Empty, "class", "button-close__container");
            }

            CheckIfElementContainsText("You don't have any websites yet. Click Get Started to create your first website.", "h5");
            Actions action = new Actions(driver);
            var element = driver.FindElement(HelperFactory.SelectorByAttributeValue("data-qa", "popupwindow-icon-userprofile"));
            action.MoveToElement(element).Perform();
            ClickTheButtonByAttributeValue(String.Empty, "data-qa", "popupwindow-link-logout");
        }
    }
}
