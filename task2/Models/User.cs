namespace task2.Models
{
    public class User
    {
        public string Email {  get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsActive { get; set; }
    }
}
