using course.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace course.Controllers
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
            return View("CollegeList",Colleges());
        }

        public IActionResult Test() => View();

        List<College> Colleges()
        {
            List<College> colleges = new List<College>();

            StreamReader r = new StreamReader("wwwroot/courses.json");
            string jsonString = r.ReadToEnd();

            var courses = JObject.Parse(jsonString);
            foreach (var c in (JObject)courses["colleges"])
            {
                colleges.Add(new College(c.Key));
            }

            return colleges;
        }

    }
}