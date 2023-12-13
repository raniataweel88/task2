namespace task2.DTO.Courses
{
    public class UpdateCoursesDTO
    {
        public int CoursesId { get; set; }
        public string InstructorName { get; set; }
        public int Price { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
