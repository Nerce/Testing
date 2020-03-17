using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TechTalk.SpecFlow;

namespace TestTask.Hooks
{

    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext scenarioContext;
        private ChromeDriver driver;
        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
       //     Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

         //   foreach (var chromeDriverProcess in chromeDriverProcesses)
         //   {
          //      chromeDriverProcess.Kill();
           // }
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://zyro.com/");
            scenarioContext.Add("currentDriver", driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}
