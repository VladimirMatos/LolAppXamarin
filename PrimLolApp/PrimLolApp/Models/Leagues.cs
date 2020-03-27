using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models
{
    public class LeaguePointsQueue
    {

        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }

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

        [JsonProperty("veteran")]
        public bool Veteran { get; set; }

        [JsonProperty("inactive")]
        public bool Inactive { get; set; }

        [JsonProperty("freshBlood")]
        public bool FreshBlood { get; set; }

        [JsonProperty("hotStreak")]
        public bool HotStreak { get; set; }


        public string Region { get; set; }
        public string Match { get; set; }
        public string elo { get; set; }
        public string page { get; set; }
    }

    public class RankedIngo
    {
        public IList<LeaguePointsQueue> LeaguePoints { get; set; }
    }
}
