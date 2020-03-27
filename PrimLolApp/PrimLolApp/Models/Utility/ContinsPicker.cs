using PrimLolApp.Models.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models.Utility
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
