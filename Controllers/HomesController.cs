using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleASPCore.Models;
using System;

namespace SampleASPCore.Controllers
{
    public class HomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IndexHitung(double bil1, double bil2)
        {
            try
            {
                double hasil = bil1*bil2;

                ViewBag.bil1 = bil1;
                ViewBag.bil2 = bil2;
                ViewData["hasil"] = hasil;
                return View();
            }
            catch (Exception ex)
            {
                return Content($"{ex.Message}");
            }
        }

        public IActionResult GetData()
        {
            Restaurant resto = new Restaurant
            {
                Id = 11,
                Name = "Gudeg Yu Djum",
                Address = "JL Solo No 12"
            };
            ViewData["resto"] = resto;

            return View();
            //return new JsonResult(resto);
        }
    }


}