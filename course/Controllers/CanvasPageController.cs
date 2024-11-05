using Microsoft.AspNetCore.Mvc;
using course.Models;

namespace course.Controllers
{
    public class CanvasPageController : Controller
    {
        public IActionResult Welcome(Course course) => View(course);

        public IActionResult Map(Course course) => View(course);
    }
}
