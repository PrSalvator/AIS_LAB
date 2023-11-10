using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.Models
{
    public class Users
    {
        [JsonProperty("items")]
        public List<User> UsersList { get; set; }
    }
}
