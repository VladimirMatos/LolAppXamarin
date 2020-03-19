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
            var result = await httpClient.GetStringAsync(Config.url);
            return JsonConvert.DeserializeObject<SummonersInf>(result);
        }
    }
}
