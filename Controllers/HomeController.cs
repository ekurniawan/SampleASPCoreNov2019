using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.Controllers
{
    //[Route("MyFile")]
    public class HomeController : Controller
    {
        private IConfiguration _config;
        private IGreeter _greeter;

        public HomeController(IConfiguration config,IGreeter greeter)
        {
            _config = config;
            _greeter = greeter;
        }
        //[Route("Index")]
        public IActionResult Index()
        {
            return Content(_greeter.GetMessageOfTheDay());
        }

        public IActionResult About()
        {
            var dataConfig = _config["Greeting"];
            return Content($"Data Config: {dataConfig}");
        }

        //[Route("Dokumen/Contact")]
        public IActionResult Contact(){
            return View("Hello");
        }
     
    }
}