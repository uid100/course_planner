using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using course.Models;

namespace course.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult CourseList(College college)
        {
            String x = "stop";
            return View(Courses(college));
        }

        public IActionResult CourseDetail(Course course)
        {
            StreamReader r = new StreamReader("wwwroot/courses.json");
            string jsonString = r.ReadToEnd();

            var jsonObject = JObject.Parse(jsonString);

            var c = jsonObject["colleges"][course.College][course.Name];

            course.CatalogID = (string)c["CatalogID"];
            course.LongName = (string)c["LongName"];
            course.Term = (string)c["Term"];
            course.TermStart = DateTime.Parse(s: (string)c["Start"]);
            course.TermEnd = DateTime.Parse(s: (string)c["End"]);
            course.Status = (string)c["status"];

            int count = 0;

            course.Modules = new List<Module>();
            foreach(var jsonEntry in c["modules"])
            {
                string key = "Module " + count++;
                var m = jsonEntry.First;
                if (m is not null)
                {
                    try
                    {
                        Module module = new Module();
                        module.Title = (string)m["title"];
                        module.Week = (int)m["week"];
                        course.Modules.Add(module);
                    }
                    catch (Exception ex)
                    {
                        int x = 0;
                    }
                }
            }
            return View(course);
        }

        List<Course> Courses(College college)
        {
            List<Course> courses = new List<Course>();

            StreamReader r = new StreamReader("wwwroot/courses.json");
            string jsonString = r.ReadToEnd();

            var jsonObject = JObject.Parse(jsonString);

            foreach (var c in jsonObject["colleges"][college.Name] as JObject)
            {
                var course = new Course();
                course.College = college.Name;
                course.Name = c.Key;
                courses.Add(course);
            }

            return courses;
        }
    }
}

