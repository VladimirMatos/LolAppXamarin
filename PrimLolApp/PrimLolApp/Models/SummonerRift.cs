using Newtonsoft.Json;
using System.ComponentModel;

namespace PrimLolApp.Models
{

    public class SummonerRift : INotifyPropertyChanged
    {

        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        public SummonerRift()
        {
            Emblem = "PrimLolApp/Utility/Emblem" + Tier + ".png";
        }

        public string Emblem { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

    }

}
