using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MC5_U3_TravelPlanner
{
    public class Departure
    {
        [JsonPropertyName("depart")]
        public string Depart { get; set; }

        [JsonPropertyName("departureTime")]
        public string DepartureTime { get; set; }

        [JsonPropertyName("arrive")]
        public string Arrive { get; set; }

        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }
    }
}
