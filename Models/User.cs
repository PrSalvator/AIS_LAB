using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("bdate")]
        public string BDay { get; set; }
        [JsonProperty("photo_100")]
        public string PhotoUrl { get; set; }
    }
}
