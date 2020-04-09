using PrimLolApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimLolApp.Services
{
    public interface IApiService
    {
        Task<SummonersInf> GetSummonersInfo(string region, string summonerName);
        Task<TierList> GetTierList(string Region);
        Task<List<LeaguePointsQueue>> GetMatchRank(string Region, string Match, string league, string division);
        Task<List<SummonerRift>> GetSummonerRift(string Region, string ID);
    }
}
