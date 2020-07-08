using System;
using OtpNet;

namespace TestTask.Helpers
{
    
    public class TwoStepAuthCode
    {
        private string otpKeyStr = "b5dvftvjmzdgnxfg";

      public string get2FACode()
        {
            var otpKeyBytes = Base32Encoding.ToBytes(otpKeyStr);
            var totp = new Totp(otpKeyBytes);
            var twoFactorCode = totp.ComputeTotp(); // <- got 2FA coed at this time!
            return twoFactorCode;
        }

    }
}
