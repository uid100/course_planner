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
            return View(Courses(college));
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
                            catch (Exception ex) { }
                        }
                    }
                }
                catch (Exception ex) { }

                try
                {
                    foreach (var jsonEntry in c["assignments"]["Projects"])
                    {
                        try
                        {
                            string projectTitle = (string)jsonEntry["title"];
                            int moduleNumber = (int)jsonEntry["module"];
                            course.Modules[moduleNumber].ToDo = projectTitle;
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
                            string discussion = (string)jsonEntry["title"];
                            int moduleNumber = (int)jsonEntry["module"];
                            course.Modules[moduleNumber].Discussion = discussion;
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
                            string projectTitle = (string)jsonEntry["title"];
                            int moduleNumber = (int)jsonEntry["module"];
                            course.Modules[moduleNumber].Exam = projectTitle;
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
                            string projectTitle = (string)jsonEntry["title"];
                            int moduleNumber = (int)jsonEntry["module"];
                            course.Modules[moduleNumber].Exam = projectTitle;
                        }
                        catch (Exception ex)
                        {
                            int x = 0;
                        }
                    }
                }
                catch (Exception ex) { }
            }

            return View(course);
        }

        List<Course> Courses(College college)
        {
            List<Course> courses = new List<Course>();

            string jsonString;
            using (StreamReader r = new StreamReader("wwwroot/courses.json"))
            {
                jsonString = r.ReadToEnd();
            }

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

