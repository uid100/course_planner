namespace course.Models
{
    public class TestCollegeRepo : ICollegeRepository
    {
        // private int _id = 1001;

        public IQueryable<College> Colleges => new List<College>
        {
            //new College { Id=_id++, Name = "Faber College" },
            //new College { Id=_id++, Name = "Monsters University" },
            //new College { Id=_id++, Name = "Pennbrook University" }
            new College { Name = "Faber College" },
            new College { Name = "Monsters University" },
            new College { Name = "Pennbrook University" }
        }.AsQueryable<College>();
    }
}
