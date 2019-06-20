using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieApp.Entities.Server
{
    public class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "original_title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public float UserScore { get; set; }

        [JsonProperty(PropertyName ="genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty(PropertyName = "production_companies")]
        public List<ProductionCompany> Companies { get; set; }

        public string UserCorePercent
        {
            get
            {
                return string.Format("{0}%", UserScore*10);
            }
        }

        //public string UserCoreFloat
        //{
        //    get
        //    {
        //        return string.Format("{0}", UserScore);
        //    }
        //}

        public string PosterImgUrl
        {
            get
            {
                return string.Concat("https://image.tmdb.org/t/p/w300_and_h450_bestv2/", PosterPath);
            }
        }

    }
}
