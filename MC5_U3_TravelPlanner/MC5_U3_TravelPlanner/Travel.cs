using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MC5_U3_TravelPlanner
{
    public class Travel
    {
        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("ToLinz")]
        public List<TravelTime> ToLinz { get; set; }

        [JsonPropertyName("FromLinz")]
        public List<TravelTime> FromLinz { get; set; }
    }

    public class TravelTime
    {
        [JsonPropertyName("Leave")]
        public string Leave { get; set; }

        [JsonPropertyName("Arrive")]
        public string Arrive { get; set; }
    }
}
