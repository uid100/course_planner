namespace course.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
    }
}
