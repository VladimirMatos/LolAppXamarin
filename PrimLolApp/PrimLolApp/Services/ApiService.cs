using Newtonsoft.Json;
using PrimLolApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimLolApp.Services
{
    public class ApiService : IApiService
    {

        public async Task<SummonersInf> GetSummonersInfo(string region, string summonerName)
        {
            HttpClient httpClient = new HttpClient();
            var Summoners = await httpClient.GetStringAsync($"{Config.IniUrl}{region}{Config.UrlSummoner}{Config.FindUsers}{summonerName}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<SummonersInf>(Summoners);
        }

        public async Task<TierList> GetTierList(string RegionTL)
        {
            HttpClient httpClient = new HttpClient();
            var TierList = await httpClient.GetStringAsync($"{Config.IniUrl}{RegionTL}{Config.UrlTierList}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<TierList>(TierList);
        }

        public async Task<List<LeaguePointsQueue>> GetMatchRank(string RegionMR, string Match, string league, string division)
        {
            HttpClient webClient = new HttpClient();
            Uri uri = new Uri($"{Config.IniUrl}{RegionMR}{Config.UrlMatchElo}{Match}/{league}/{division}?page=1&api_key={Config.ApiKey}");
            HttpResponseMessage response = await webClient.GetAsync(uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LeaguePointsQueue>>(jsonString);

        }

        public async Task<List<SummonerRift>> GetSummonerRift(string Region, string ID)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri($"{Config.IniUrl}{Region}{Config.UrlSummonerRift}{ID}?api_key={Config.ApiKey}");
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<SummonerRift>>(jsonString);
        }

    }
}
