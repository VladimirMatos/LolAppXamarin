using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrimLolApp.Models
{
    public class Players : INotifyPropertyChanged
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
        public string Region { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TierList: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("players")]
        public IList<Players> PlayersInfo { get; set; }
    }

}
