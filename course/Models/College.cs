namespace course.Models
{
    public class College
    {
        public College() => this.Name = "none";
        public College( string n = "not found" ) => this.Name = n;

        public string? Name { get; set; }

        public static List<College>? colleges;
    }
}
