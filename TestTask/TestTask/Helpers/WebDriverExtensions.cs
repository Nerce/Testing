using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;

namespace TestTask
{
    [Binding]
    public class WebDriverExtensions
    {

        private ChromeDriver driver;

        public WebDriverExtensions(ScenarioContext scenarioContext)
        {
            driver = scenarioContext.Get<ChromeDriver>("currentDriver");
        }

        public IWebElement FindElement(By by, int timeoutInSeconds=10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(driver => driver.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(driver => (driver.FindElements(by).Count > 0) ? driver.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }
        public IWebElement FindSearchElement(ISearchContext context, By by, uint timeout, bool displayed = false)
        {
            var wait = new DefaultWait<ISearchContext>(context);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ctx =>
            {
                var elem = ctx.FindElement(by);
                if (displayed && !elem.Displayed)
                    return null;

                return elem;
            });
        }
    }
}