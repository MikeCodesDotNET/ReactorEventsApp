using System;
using Newtonsoft.Json;

namespace ReactorToday.Shared.Models
{
    public class Location
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("GeoPoint")]
        public GeoPoint GeoPoint { get; set; }

        [JsonProperty("DistanceFromUser")]
        public object DistanceFromUser { get; set; }
    }
}
