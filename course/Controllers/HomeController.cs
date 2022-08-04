using Microsoft.AspNetCore.Mvc;

namespace course.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICollegeRepository _colleges;

        public HomeController(
            ILogger<HomeController> logger,
            ICollegeRepository colleges)
        {
            _logger = logger;
            _colleges = colleges;
        }

        public IActionResult Index()
        {
            return View("CollegeList", _colleges.Colleges);
        }

        // TODO: Add Todo List Controller and Views (and json dataset)
        public IActionResult ToDoList() => View("Index");
    }
}