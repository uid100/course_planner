using Newtonsoft.Json.Linq;

namespace course.Models
{
    public class JsonCollegeRepo : ICollegeRepository
    {
        private string _filename;
        private readonly IConfiguration _config;

        public JsonCollegeRepo(IConfiguration config)
        {
            _filename = config.GetValue<string>("JsonCourseData");
        }

        public IQueryable<College> Colleges {
            get 
            {
                //int _id = 1001;
                List<College> colleges = new List<College>();
                using (StreamReader r = new StreamReader(_filename))
                {
                    var jsonString = r.ReadToEnd();
                    JObject keyValuePairs = JObject.Parse(jsonString);
                    foreach (var c in (JObject)keyValuePairs["colleges"])
                    {
                        //colleges.Add(new College { Id = _id++, Name = (string)c.Key });
                        colleges.Add(new College { Name = (string)c.Key });
                    }
                }

                return colleges.AsQueryable<College>();
            }
        }
    }
}
