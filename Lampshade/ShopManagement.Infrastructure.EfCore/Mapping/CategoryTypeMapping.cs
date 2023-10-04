using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CategoryTypeAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class CategoryTypeMapping : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.ToTable("CategoryTypes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasMany(x => x.ProductCategories)
                .WithOne(x => x.CategoryType)
                .HasForeignKey(x => x.CategoryTypeId);
        }
    }
}
