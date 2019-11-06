using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }

}
