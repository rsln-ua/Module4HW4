using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class ShippersConfiguration : IEntityTypeConfiguration<ShipperEntity>
{
    public void Configure(EntityTypeBuilder<ShipperEntity> builder)
    {
        builder.Property(el => el.CompanyName).IsRequired();
        builder.HasMany(el => el.Orders).WithOne(el => el.ShipperEntity)
            .HasForeignKey(el => el.ShipperId).IsRequired();
    }
}