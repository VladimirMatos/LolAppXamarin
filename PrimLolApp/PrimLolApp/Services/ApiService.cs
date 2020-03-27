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
        public async Task<SummonersInf> GetSummonersInfo(string region, string summonerName)
        {
            HttpClient httpClient = new HttpClient();
            var Summoners = await httpClient.GetStringAsync($"{IniUrl}{region}{Config.UrlSummoner}{FindUsers}{summonerName}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<SummonersInf>(Summoners);
        }

        public async Task<TierList> GetTierList(string RegionTL)
        {
            HttpClient httpClient = new HttpClient();
            var TierList = await httpClient.GetStringAsync($"{IniUrl}{RegionTL}{Config.UrlTierList}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<TierList>(TierList);
        }
     
        public async Task<List<LeaguePointsQueue>> GetMatchRank(string RegionMR, string Match, string league, string division)
        {
            HttpClient webClient = new HttpClient();
            Uri uri = new Uri($"{IniUrl}{RegionMR}{Config.UrlMatchElo}{Match}/{league}/{division}?page=1&api_key={Config.ApiKey}");
            HttpResponseMessage response = await webClient.GetAsync(uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LeaguePointsQueue>>(jsonString);

        }
        public async Task<ServerStatus> GetServerStatus(string RegionSS)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri($"{IniUrl}{RegionSS}{Config.UrlServerStatus}?api_key={Config.ApiKey}");
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServerStatus>(jsonString);
        }

    }
}
