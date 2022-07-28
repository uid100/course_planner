namespace course.Models
{
    public class Assignment
    {
        public string? Title { get; set; }
        public int Days { get; set; }
    }

    public class Discussion : Assignment
    {
    }
    public class Exam : Assignment
    {
    }
    public class Project : Assignment
    {
    }
    public class Quiz : Assignment
    {
    }
}
