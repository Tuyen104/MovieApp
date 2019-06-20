using System;
namespace MovieApp.Services
{
    public interface IConfigurationService
    {
        string MovieBaseUrl { get; }
    }

    public class ConfigurationService : IConfigurationService
    {
        public string MovieBaseUrl => "https://api.themoviedb.org/3";
    }
}
