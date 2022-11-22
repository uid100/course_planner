namespace course.Models
{
    public class Course
    {
        public String? College { get; set; }
        public String? CatalogID { get; set; }
        public String? Name { get; set; }
        public String? LongName { get; set; }
        public String? Term { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }
        public string? Status { get; set; }
        public List<Module>? Modules { get; set; }
        public int? CanvasID { get; set; }
        public string? CanvasURL { get; set; }
    }
}
