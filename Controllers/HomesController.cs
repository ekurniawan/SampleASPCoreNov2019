using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.Controllers
{
    public class HomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexHitung(double bil1, double bil2)
        {
            double hasil = bil1*bil2;
            return Content($"Hasilnya : {hasil}");
        }
    }


}