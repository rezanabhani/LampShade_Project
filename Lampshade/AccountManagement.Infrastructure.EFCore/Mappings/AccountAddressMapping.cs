using AccountManagement.Domain.AccountAddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mappings
{
    public class AccountAddressMapping : IEntityTypeConfiguration<AccountAddress>
    {
        public void Configure(EntityTypeBuilder<AccountAddress> builder)
        {
            builder.ToTable("AccountAddresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.State).HasMaxLength(150).IsRequired();
            builder.Property(x => x.City).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PostalCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.CompleteAddress).HasMaxLength(700).IsRequired();


            builder.HasOne(x => x.UserAddress)
                .WithOne(x => x.AccountAddress)
                .HasForeignKey<AccountAddress>(x => x.AccountId);

            builder.Navigation(x => x.UserAddress).AutoInclude();
        }
    }
}
