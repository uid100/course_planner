using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using course.Models;

namespace course.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courses;

        public CourseController(ICourseRepository courses)
        {
            _courses = courses;
        }
        public IActionResult CourseList(College college)
        {
            return View(_courses.Courses.Where(c=>c.College == college.Name));
        }

        public IActionResult CourseDetail(Course course)
        {
            string jsonString = "";
            using (var r = new StreamReader("wwwroot/courses.json"))
            {
                jsonString = r.ReadToEnd();
            }

            JObject jsonObject = JObject.Parse(jsonString);

            JToken? c = jsonObject["colleges"][course.College][course.Name];
            if( c!= null) 
            {
                course.CatalogID = (string)c["CatalogID"];
                course.CanvasID = (int)c["CanvasCourseID"];
                course.Name = course.Name;
                course.LongName = (string)c["LongName"];
                course.Term = (string)c["Term"];
                course.TermStart = DateTime.Parse(s: (string)c["Start"]);
                course.TermEnd = DateTime.Parse(s: (string)c["End"]);
                course.Status = (string)c["status"];

                int count = 0;

                course.Modules = new List<Module>();
                try
                {
                    foreach (var jsonEntry in c["modules"])
                    {
                        try
                        {
                            Module module = new Module();
                            module.Id = (int)jsonEntry["module"];
                            module.Title = (string)jsonEntry["title"];
                            module.Week = (int)jsonEntry["week"];
                            course.Modules.Add(module);
                        }
                        catch (Exception ex) { }
                    }
                }
                catch (Exception ex) { }

                try
                {
                    foreach (var jsonEntry in c["assignments"]["Projects"])
                    {
                        try
                        {                            
                            int moduleNumber = (int)jsonEntry["module"];
                            int index = course.Modules.FindIndex(module => module.Id == moduleNumber);
                            course.Modules[index].ToDo = new Project();
                            course.Modules[index].ToDo.Title = (string)jsonEntry["title"];
                            course.Modules[index].ToDo.Days = (int)jsonEntry["days"];
                        }
                        catch (Exception ex) { }
                    }
                }
                catch (Exception ex) { }

                try
                {
                    foreach (var jsonEntry in c["assignments"]["Discussions"])
                    {
                        try
                        {
                            int moduleNumber = (int)jsonEntry["module"];
                            int index = course.Modules.FindIndex(module => module.Id == moduleNumber);
                            course.Modules[index].Discussion = new Discussion();
                            course.Modules[index].Discussion.Title = (string)jsonEntry["title"];
                            course.Modules[index].Discussion.Days = (int)jsonEntry["days"];
                        }
                        catch (Exception ex) { }
                    }
                }

                catch (Exception ex) { }
                try
                {
                    foreach (var jsonEntry in c["assignments"]["Quizzes"])
                    {
                        try
                        {
                            int moduleNumber = (int)jsonEntry["module"];
                            int index = course.Modules.FindIndex(module => module.Id == moduleNumber);
                            course.Modules[index].Quiz = new Quiz();
                            course.Modules[index].Quiz.Title = (string)jsonEntry["title"];
                            course.Modules[index].Quiz.Days = (int)jsonEntry["days"];
                        }
                        catch (Exception ex) { }
                    }
                }
                catch (Exception ex) { }
                try
                {
                    foreach (var jsonEntry in c["assignments"]["Exams"])
                    {
                        try
                        {
                            int moduleNumber = (int)jsonEntry["module"];
                            int index = course.Modules.FindIndex(module => module.Id == moduleNumber);
                            course.Modules[index].Exam = new Exam();
                            course.Modules[index].Exam.Title = (string)jsonEntry["title"];
                            course.Modules[index].Exam.Days = (int)jsonEntry["days"];
                        }
                        catch (Exception ex) { }
                    }
                }
                catch (Exception ex) { }
            }

            return View(course);
        }
    }
}

