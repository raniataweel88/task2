namespace task2.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual List<Courses> Coursess { get; set; }
        
    }
}
