using System.Collections.Generic;

namespace PrimLolApp.Utility
{
    public class ContinsPicker
    {
        public static List<Contins> GetContinents()
        {
            var Conti = new List<Contins>()
            {
                new Contins(){LolCont ="americas"},
                new Contins(){LolCont ="asia"},
                new Contins(){LolCont ="europe"},

            };
            return Conti;
        }

    }
}
