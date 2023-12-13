using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task2.Models.EntityConfigartion
{
    public class CoursesEntityConfiguration : IEntityTypeConfiguration<Courses>
    {

        void IEntityTypeConfiguration<Courses>.Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasKey(x => x.CoursesId);
            builder.Property(x=>x.CoursesId).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
