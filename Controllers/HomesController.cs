using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.Controllers
{
    public class HomesController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }


}