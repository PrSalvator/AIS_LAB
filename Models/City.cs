using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.Models
{
    public class City
    {
        [JsonProperty("title")]
        public string Name { get; set; }
    }
}
