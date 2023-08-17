using CarWorkshop.MVCv2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarWorkshop.MVCv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About() {

            List<About> model = new List<About>
            {
                new About()
                {
                    ID = 1,
                    Title = "Test1",
                    Description = "TestTest1",
                    Tags = new List<string> {"tag11", "tag12", "tag13"}
                },
                new About()
                {
                    ID = 2,
                    Title = "Test2",
                    Description = "TestTest2",
                    Tags = new List<string> {"tag21", "tag22", "tag23"}
                }
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}