using SampleASPCore.Models;
using SampleASPCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Data
{
    public interface IRestaurantData : ICrud<Restaurant>
    {
        Task<IEnumerable<ViewRestoWithCategory>> GetFancyResto();
    }
}
