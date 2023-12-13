using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task2.Models.EntityConfigartion
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {

            void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).UseIdentityColumn().IsRequired();
        }
    }
}
