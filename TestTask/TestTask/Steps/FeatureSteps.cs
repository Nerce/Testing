using OpenQA.Selenium.Chrome;
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
            var usernameField = driver.FindElement(HelperFactory.SelectorByAttributeValue("name", "q"));
            usernameField.SendKeys("123121313");

        }
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            scenarioContext.Pending();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            scenarioContext.Pending();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            scenarioContext.Pending();
        }
    }
}
