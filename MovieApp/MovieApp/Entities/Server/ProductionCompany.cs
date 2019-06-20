using System;
using Newtonsoft.Json;

namespace MovieApp.Entities.Server
{
    public class ProductionCompany
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "origin_country")]
        public string Country { get; set; }
    }
}
