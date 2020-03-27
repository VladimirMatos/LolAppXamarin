using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.Models.Utility
{
    public class DivisionPicker
    {
        public static List<Division> GetDivision()
        {
            var TypeMatchs = new List<Division>()
            {
                new Division(){MyDivision ="I"},
                new Division(){MyDivision ="II"},
                new Division(){MyDivision ="III"},
                new Division(){MyDivision ="IV"}

            };
            return TypeMatchs;
        }
    }
}
