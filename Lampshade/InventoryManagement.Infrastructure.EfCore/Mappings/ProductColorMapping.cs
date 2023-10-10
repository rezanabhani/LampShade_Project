using InventoryManagement.Domain.ProductColorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EfCore.Mappings
{
    public class ProductColorMapping : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.ToTable("ProductColors");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Color).HasMaxLength(700).IsRequired();
            builder.Property(x => x.ColorP).HasMaxLength(700).IsRequired();

        }
    }
}
