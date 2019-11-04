using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.Controllers
{
    //[Route("MyFile")]
    public class HomeController : Controller
    {
        private IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        //[Route("Index")]
        public IActionResult Index(string myid,string nama)
        {
            return Content($"Hello Nama anda: {nama} dan ID: {myid}");
        }

        public IActionResult About()
        {
            var dataConfig = _config["Greeting"];
            return Content($"Data Config: {dataConfig}");
        }


        //[Route("Dokumen/Contact")]
        public IActionResult Contact(){
            return Content("Contact");
        }
     
    }
}