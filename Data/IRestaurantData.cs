using SampleASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll();
    }
}
