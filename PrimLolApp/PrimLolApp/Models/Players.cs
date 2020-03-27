using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models
{
    public class Players
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
        public string Region { get; set; }
    } 
        
    public class TierList
    {

        [JsonProperty("players")]
        public IList<Players> PlayersInfo { get; set; }
    }

}
