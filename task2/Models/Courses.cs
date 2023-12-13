namespace task2.Models
{
    public class Courses
    {
        public int CoursesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public virtual Instructor Instructor { get; set; }

        public int Price { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
