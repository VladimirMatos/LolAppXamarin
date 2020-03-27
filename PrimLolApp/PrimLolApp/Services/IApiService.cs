using PrimLolApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimLolApp.Services
{
    public interface IApiService
    {
        Task<SummonersInf> GetSummonersInfo(string summonerName);
        Task<TierList> GetTierList(string Region);
        Task<Servers> GetServerStatus(string Region);
        Task<LeaguePointsQueue> GetMatchRank(string Region);
    }
}
