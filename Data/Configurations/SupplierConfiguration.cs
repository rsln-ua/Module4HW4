using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
{
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.Property(el => el.CompanyName).IsRequired();
        builder.Property(el => el.ContactFName).IsRequired();
        builder.Property(el => el.ContactLName).IsRequired();
        builder.HasMany(el => el.Products).WithOne(el => el.SupplierEntity)
            .HasForeignKey(el => el.SupplierId).IsRequired();
        builder.Property(el => el.CustomerId).IsRequired();
    }
}