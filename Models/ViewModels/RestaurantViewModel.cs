using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models.ViewModels
{
    public class RestaurantViewModel
    {
        public IEnumerable<Restaurant> Restaurant { get; set; }
        public Customer Customer { get; set; }

    }
}
