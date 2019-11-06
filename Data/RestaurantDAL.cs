using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.Data
{
    public class RestaurantDAL : IRestaurantData
    {
        private IConfiguration _config;
        public RestaurantDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
