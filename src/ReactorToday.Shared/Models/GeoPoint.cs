using System;
using Newtonsoft.Json;

namespace ReactorToday.Shared.Models
{
    public class GeoPoint
    {
        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }
    }
}
