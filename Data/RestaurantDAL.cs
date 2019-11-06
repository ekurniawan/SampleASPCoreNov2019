using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

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

        /*public IEnumerable<Restaurant> GetAll()
        {
            List<Restaurant> lstRestaurant = new List<Restaurant>();
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Restaurants order by Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstRestaurant.Add(new Restaurant
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString(),
                            Address = dr["Address"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstRestaurant;
        }*/

        /*public Restaurant GetById(int id)
        {
            Restaurant resto = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Restaurants where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    resto = new Restaurant
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString()
                    };
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }

            return resto;
        }*/

        public Task<IEnumerable<Restaurant>> GetFancyResto()
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> GetById(string id)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Restaurants where Id=@Id";
                var par = new { Id = id };
                var result = await conn.QuerySingleAsync<Restaurant>(strSql, par);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Error: data tidak ditemukan..");
                }
            }
        }

        public async Task<Restaurant> Insert(Restaurant obj)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSq = @"insert into Restaurants(Name,Address) values(@Name,@Address)";
                try
                {
                    var param = new { Name = obj.Name, Address = obj.Address };
                    int result = await conn.ExecuteAsync(strSq, param);
                    if (result == 1)
                    {
                        return obj;
                    }
                    else
                    {
                        throw new Exception("Tambah data gagal");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
            
        }

        public Task<Restaurant> Update(Restaurant obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Restaurants order by Name asc";
                var results = await conn.QueryAsync<Restaurant>(strSql);

                return results;
            }
        }
    }
}
