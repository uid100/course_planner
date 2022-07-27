using Microsoft.AspNetCore.Mvc;
using course.Models;

namespace course.Controllers
{
    public class CanvasPageController : Controller
    {
        //[HttpGet]
        //public IActionResult Welcome() => View();

        //[HttpPost]
        public IActionResult Welcome(Course course)
        {
            int x = 0;
            return View(course);
        }
    }
}
