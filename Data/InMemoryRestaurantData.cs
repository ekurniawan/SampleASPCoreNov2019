using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> listRestaurant;
        public IEnumerable<Restaurant> GetAll()
        {
            listRestaurant = new List<Restaurant>
            {
                new Restaurant {Id=1,Name="Gudeg Yu Djum",Address="Jl Solo 11"},
                new Restaurant {Id=2,Name="Sate Klathak",Address="Jl Magelang 22"},
                new Restaurant {Id=3,Name="Bakpia Pathuk",Address="Jl Mangkubumi 33"}
            };

            return listRestaurant;
        }
    }
}
