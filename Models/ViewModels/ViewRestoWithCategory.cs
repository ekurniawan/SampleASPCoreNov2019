using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models.ViewModels
{
    public class ViewRestoWithCategory
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
