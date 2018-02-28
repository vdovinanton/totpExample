using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtpSharp;
using Base32;

namespace otpAppp
{
    public interface IMfaService
    {
        Task ValidateAsync(string token);
    }

    public class TotpService
    {
        private readonly static string _secretKey = "qweqweqweqw";
        public bool ValidateAsync(string token)
        {
            long timeStepMatched = 0;

            byte[] decodedKey = Base32Encoder.Decode(_secretKey);
            var otp = new Totp(decodedKey);
            otp.ComputeTotp();
            bool valid = otp.VerifyTotp(token, out timeStepMatched, new VerificationWindow(2, 2));

            return valid;
        }
    }
}
