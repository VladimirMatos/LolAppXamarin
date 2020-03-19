using PrismLolApp.Models;
using System;
using System.Threading.Tasks;

namespace PrismLolApp.Services
{
    public interface IApiService
    {
        Task<SummonersInf> GetSummonersInfo(string summonerName); 
        
    }
}
