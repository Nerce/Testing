using System;

namespace TestTask
{
    class User
    {
        
        public string Email { get; set; }
        public string Password { get; set; }

        public void FillInWithUserData(int caseSwitch = default)
        {
            switch (caseSwitch)
            {
                case 1:   
     
                Random randomGenerator = new Random();
                    int randomInt = randomGenerator.Next(1000);
                    Email = ("username" + randomInt + "@gmail.com");
                    Password = "";
                    break;
                default:;
                    Email = "neringa.g@mailinator.com";
                    Password = "testas123";
                    break;
            }

        }
    }
}