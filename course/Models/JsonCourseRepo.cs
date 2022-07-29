using Newtonsoft.Json.Linq;

namespace course.Models
{
    public class JsonCourseRepo : ICourseRepository
    {
        private string _filename;

        public JsonCourseRepo(IConfiguration config)
        {
            _filename = config.GetValue<string>("JsonCourseData");
        }

        public IQueryable<Course> Courses { 
            get
            {
                List<Course> courses = new List<Course>();

                using(StreamReader r = new StreamReader(_filename))
                {
                    string jsonString = r.ReadToEnd();
                    JObject collegeData = JObject.Parse(jsonString);
                    // TODO: fix 'dereference possible null' in JsonCourseRepo.cs
                    foreach(var jsonObject in (JObject?)collegeData["colleges"])
                    {
                        string collegeName = jsonObject.Key;
                        JObject courseData = JObject.Parse(jsonString);
                        // TODO: fix 'dereference possible null' in JsonCourseRepo.cs
                        foreach (var c in courseData["colleges"][collegeName] as JObject)
                        {
                            Course course = new Course();
                            course.College = collegeName;
                            course.Name = c.Key;
                            courses.Add(course);
                        }
                    }
                }
                return courses.AsQueryable<Course>();
            }
        }
    }
}
