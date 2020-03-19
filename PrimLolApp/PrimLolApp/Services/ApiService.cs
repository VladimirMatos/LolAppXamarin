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
        const string FindUsers = "v4/summoners/by-name/";
        public async Task<SummonersInf> GetSummonersInfo(string summonerName)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync($"{Config.url}{FindUsers}{summonerName}?api_key={Config.ApiKey}");
            return JsonConvert.DeserializeObject<SummonersInf>(result);
        }
    }
}
