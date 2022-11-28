using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(el => el.CompanyName).IsRequired();
        builder.Property(el => el.ContactFName).IsRequired();
        builder.Property(el => el.ContactLName).IsRequired();
        builder.Property(el => el.Email).IsRequired();
        builder.Property(el => el.Phone).IsRequired();
        builder.HasMany(el => el.Products).WithOne(el => el.Supplier)
            .HasForeignKey(el => el.SupplierId).IsRequired();
        builder.Property(el => el.CustomerId);
    }
}