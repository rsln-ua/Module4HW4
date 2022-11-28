using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class ShippersConfiguration : IEntityTypeConfiguration<Shipper>
{
    public void Configure(EntityTypeBuilder<Shipper> builder)
    {
        builder.Property(el => el.CompanyName).IsRequired();
        builder.HasMany(el => el.Orders).WithOne(el => el.Shipper)
            .HasForeignKey(el => el.ShipperId).IsRequired();
    }
}