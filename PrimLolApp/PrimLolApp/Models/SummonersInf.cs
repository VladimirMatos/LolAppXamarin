﻿using Newtonsoft.Json;
using System.ComponentModel;

namespace PrimLolApp.Models
{
    public class SummonersInf : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("profileIconId")]
        public string ProfileIconId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }
   
   

    }
}

