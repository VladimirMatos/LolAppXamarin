using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models.Utility
{
    public class RegionsPicker
    {
       
        public static List<Regiones> GetRegion()
        {
            var Regiones = new List<Regiones>()
            {

                new Regiones(){LolRegiones="br1"},
                new Regiones(){LolRegiones="eun1"},
                new Regiones(){LolRegiones="euw1"},
                new Regiones(){LolRegiones="jp1"},
                new Regiones(){LolRegiones="kr"},
                new Regiones(){LolRegiones="la1"},
                new Regiones(){LolRegiones="la2"},
                new Regiones(){LolRegiones="na1"},
                new Regiones(){LolRegiones="oc1"},
                new Regiones(){LolRegiones="ru"},
                new Regiones(){LolRegiones="tr1"}

            };
           
            return Regiones;
           
        }
    }
}
