using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models.Utility
{
    public class MatchPickers
    {
        public static List<Matchs> GetMatchs()
        {
            var TypeMatchs = new List<Matchs>()
            {
                new Matchs(){TypeMatchs ="RANKED_SOLO_5x5"},
                new Matchs(){TypeMatchs ="RANKED_TFT"},
                new Matchs(){TypeMatchs ="RANKED_FLEX_SR"},
                new Matchs(){TypeMatchs ="RANKED_FLEX_TT"}

            };
            return TypeMatchs;
        }
    }
}
