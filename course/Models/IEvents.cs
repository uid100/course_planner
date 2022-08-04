namespace course.Models
{
    public interface IEvents
    {
        IQueryable<Event> Events { get; }
    }
}
