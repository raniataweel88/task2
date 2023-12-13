using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task2.Models.EntityConfigartion
{
    public class InstructorEntityConfiguration : IEntityTypeConfiguration<Instructor>
    {

        void IEntityTypeConfiguration<Instructor>.Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.InstructorId);
            builder.Property(x=>x.InstructorId).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
          
        }
    }
}
