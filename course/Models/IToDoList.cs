namespace course.Models
{
    public interface IToDoList
    {
        IQueryable<ToDo> ToDos { get; }
    }
}
