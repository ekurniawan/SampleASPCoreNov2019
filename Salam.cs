using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore
{
    public class Salam : IGreeter
    {
        public string GetMessageOfTheDay()
        {
            return "Salam dari ASP Core !";
        }
    }
}
