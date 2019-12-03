using System;
using System.Security.Cryptography;

namespace MovieApp.Helpers
{
    public class GenerateCodeHelpers 
    {
        public static string GetMovieBookingVerifier()
        {
            var buffer = new byte[32];
            new RNGCryptoServiceProvider().GetBytes(buffer);
            var verifier = Convert.ToBase64String(buffer)
                                  .Replace('+', '-')
                                  .Replace('/', '_')
                                  .Replace("=", "");
            return verifier;
        }
    }
}
