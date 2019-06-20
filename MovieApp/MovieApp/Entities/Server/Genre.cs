using System;
using Newtonsoft.Json;

namespace MovieApp.Entities.Server
{
    public class Genre
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
