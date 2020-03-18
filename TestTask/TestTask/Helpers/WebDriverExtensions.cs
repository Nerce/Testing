using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;

namespace TestTask
{

    public class WebDriverExtensions
    {

        private ChromeDriver driver;

        public WebDriverExtensions(ScenarioContext scenarioContext)
        {
            driver = scenarioContext.Get<ChromeDriver>("currentDriver");
        }

        public IWebElement FindElement(By by, int timeoutInSeconds = 10)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(driver => driver.FindElement(by));
                }
                return driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + driver.FindElement(by) + "' was not found in current context page.");
                throw;
            }
            catch (StaleElementReferenceException)
            {
                Console.WriteLine("Element with locator: '" + driver.FindElement(by) + "' was not found in current context page.");
                throw;
            }
        }
    }
}