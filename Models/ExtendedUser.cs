using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.Models
{
    class ExtendedUser : User
    {
        private string sex;
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("sex")]
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                switch (value)
                {
                    case "1":
                        sex = "Женский";
                        break;
                    case "2":
                        sex = "Мужской";
                        break;
                    default :
                        sex= "Неопределен";
                        break;
                }
            }
        }
    }

}
