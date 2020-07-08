using TestTask.WebElements;
using OpenQA.Selenium.Chrome;
using System;

namespace TestTask.Helpers
{
    public class LoginToMicrosoftAccount
    {
        private ChromeDriver driver;

        public LoginToMicrosoftAccount(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public TimeSpan MyDefaultTimeout { get; private set; }

        public void LoginToMicrosoftAccount1()
        {

            InputField inputfield = new InputField(driver);
            User user = new User();
            user.FillInWithUserData();
            inputfield.EnterValueIntoInputFieldByAttributeValue("type", "email", user.Email);
            Button button = new Button(driver);
            button.ClickTheButtonByAttributeValue("id", "idSIButton9");
            inputfield.EnterValueIntoInputFieldByAttributeValue("type", "password", user.Password);
            button.ClickTheButtonByAttributeValue("type", "submit");
            var twoStepsAuthCode = new TwoStepAuthCode();
            inputfield.EnterValueIntoInputFieldByAttributeValue("name", "otc", twoStepsAuthCode.get2FACode());
            button.ClickTheButtonByAttributeValue("type", "submit");
            System.Threading.Thread.Sleep(10000);
        }
    }
}
