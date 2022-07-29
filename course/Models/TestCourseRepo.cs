namespace course.Models
{
    public class TestCourseRepo : ICourseRepository
    {
        public IQueryable<Course> Courses => new List<Course>
        {
            new Course { CollegeID = 1, CatalogID = "CULT-100", Name = "BasketWeaving", TermStart=DateTime.Parse("1/1/2000"), TermEnd=DateTime.Parse("2/28/2000")},
            new Course { CollegeID = 3, CatalogID = "ECON-050", Name = "Adding Numbers", TermStart=DateTime.Parse("1/1/2000"), TermEnd=DateTime.Parse("2/28/2000")}
        }.AsQueryable<Course>();
    }
}
