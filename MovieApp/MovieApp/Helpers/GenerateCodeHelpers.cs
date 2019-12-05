using System;
using System.Security.Cryptography;

namespace MovieApp.Helpers
{
    public interface IGenerateCodeHelpers
    {
        string SetMovieBookingVerifier();
    }
    public class GenerateCodeHelpers : IGenerateCodeHelpers
    {
        public string SetMovieBookingVerifier()
        {
            var buffer = new byte[32];
            new RNGCryptoServiceProvider().GetBytes(buffer);
             var MovieQRCode = Convert.ToBase64String(buffer)
                                  .Replace('+', '-')
                                  .Replace('/', '_')
                                  .Replace("=", "");
            return MovieQRCode;
        }
    }
}
