namespace task2.DTO.Instructor
{
    public class GetAllInstructorDTO
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public int ?Salary { get; set; }
        public string Specifcation { get; set; }

    }
}
