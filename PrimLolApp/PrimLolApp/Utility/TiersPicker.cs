using System.Collections.Generic;

namespace PrimLolApp.Utility
{
    public class TiersPicker
    {
        public static List<Tiers> GetTiers()
        {
            var Tiers = new List<Tiers>()
            {
                new Tiers(){TierElo ="CHALLENGER"},
                new Tiers(){TierElo ="GRANDMASTER"},
                new Tiers(){TierElo ="MASTER"},
                new Tiers(){TierElo ="DIAMOND"},
                new Tiers(){TierElo ="PLATINUM"},
                new Tiers(){TierElo ="GOLD"},
                new Tiers(){TierElo ="SILVER"},
                new Tiers(){TierElo ="BRONZE"},
                new Tiers(){TierElo ="IRON"},

            };
            return Tiers;
        }
    }
}
