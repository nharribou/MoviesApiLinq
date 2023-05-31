using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Movies.Entity
{
    public class Movie
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public int Year { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Actors")]
        public List<string> Actors { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("Rating")]
        public double Rating { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }
    }

}
