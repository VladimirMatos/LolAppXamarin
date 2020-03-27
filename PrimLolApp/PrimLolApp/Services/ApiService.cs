using Newtonsoft.Json;
using PrimLolApp;
using PrimLolApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimLolApp.Services
{
    public class ApiService : IApiService
    {
        const string FindUsers = "v4/summoners/by-name/";
        const string IniUrl = " https://";
        public async Task<SummonersInf> GetSummonersInfo(string summonerName)
        {
            HttpClient httpClient = new HttpClient();
            var Summoners = await httpClient.GetStringAsync($"{Config.UrlSummoner}{FindUsers}{summonerName}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<SummonersInf>(Summoners);
        }

        public async Task <TierList> GetTierList (string RegionTL)
        {
            HttpClient httpClient = new HttpClient();
            var TierList = await httpClient.GetStringAsync($"{IniUrl}{RegionTL}{Config.UrlTierList}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<TierList>(TierList);
        }
        public async Task<Servers> GetServerStatus(string RegionSS)
        {
            HttpClient httpClient = new HttpClient();
            var ServerStatus = await httpClient.GetStringAsync($"{IniUrl}{RegionSS}{Config.UrlServerStatus}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<Servers>(ServerStatus);
        }
        public async Task<LeaguePointsQueue> GetMatchRank(string RegionMR)
        {
            HttpClient httpClient = new HttpClient();
            var RankMatch = await httpClient.GetStringAsync($"{IniUrl}{RegionMR}.api.riotgames.com/lol/league-exp/v4/entries/RANKED_SOLO_5x5/CHALLENGER/I?page=1&api_key=RGAPI-e6ab4136-c44d-4543-95b6-3e51b19017a5");
            return JsonConvert.DeserializeObject<LeaguePointsQueue>(RankMatch);
        }


    }
}
