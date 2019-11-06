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

        public InMemoryRestaurantData()
        {
            listRestaurant = new List<Restaurant>
            {
                new Restaurant {Id=1,Name="Gudeg Yu Djum",Address="Jl Solo 11"},
                new Restaurant {Id=2,Name="Sate Klathak",Address="Jl Magelang 22"},
                new Restaurant {Id=3,Name="Bakpia Pathuk",Address="Jl Mangkubumi 33"}
            };
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //var data = listRestaurant.OrderBy(r => r.Name);
            var data = from r in listRestaurant
                                 orderby r.Name ascending
                                 select r;
            return data;
        }

        public Restaurant GetById(int id)
        {
            //var result = listRestaurant.Where(r => r.Id == id).SingleOrDefault();
            var data = (from r in listRestaurant
                        where r.Id == id
                        select r).SingleOrDefault();
            return data;
        }

        public Task<Restaurant> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetFancyResto()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Restaurant obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Restaurant obj)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Restaurant>> ICrud<Restaurant>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
