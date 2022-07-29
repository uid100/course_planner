namespace course.Models
{
    public interface ICollegeRepository
    {
        IQueryable<College> Colleges { get; }
    }
}
