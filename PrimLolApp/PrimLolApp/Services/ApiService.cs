using Newtonsoft.Json;
using PrimLolApp;
using PrismLolApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrismLolApp.Services
{
    public class ApiService : IApiService
    {
        
        
        public async Task<SummonersInf> GetSummonersInfo(string summonerName)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync($"https://la1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key=RGAPI-ea00e776-7b27-4cb1-a030-cd332d8535b0");
            return JsonConvert.DeserializeObject<SummonersInf>(result);
        }
    }
}
