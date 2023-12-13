using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using task2.Models;
using task2.Models.EntityConfigartion;

namespace task2.Context
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //adding constraint on models 
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesEntityConfiguration());

        }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

    }
}
