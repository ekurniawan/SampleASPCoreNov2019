using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore
{
    public class Greeter : IGreeter
    {
        //implementasi
        public string GetMessageOfTheDay()
        {
            return "Greetings from ASP Core";
        }
    }
}
