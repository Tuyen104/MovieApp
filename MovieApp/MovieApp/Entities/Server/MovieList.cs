using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieApp.Entities.Server
{
    public class MovieList
    {
        [JsonProperty(PropertyName = "results")]
        public List<Movie> Movies { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }
    }
}
