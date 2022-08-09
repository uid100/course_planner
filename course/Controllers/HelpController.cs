using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace course.Controllers
{
    public class HelpController : Controller
    {
        private IWebHostEnvironment env;
        public HelpController(IWebHostEnvironment _env)
        {
            env = _env;
        }

        public IActionResult HelpIndex() => View();

        public FileResult Sample()
        {
            string fileName = "sample.json";
            string filePath = Path.Combine(this.env.WebRootPath, fileName);
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/plain", fileName);
        }
    }
}
