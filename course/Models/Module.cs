namespace course.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Week { get; set; }
        public Discussion? Discussion { get; set; }
        public Exam? Exam { get; set; }
        public Quiz? Quiz { get; set; }
        public Project? ToDo { get; set; }
    }
}
