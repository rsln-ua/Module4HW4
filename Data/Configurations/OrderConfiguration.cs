using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.Property(el => el.CustomerId).IsRequired();
        builder.HasOne(el => el.CustomerEntity).WithMany(el => el.Orders)
            .HasForeignKey(el => el.CustomerId).IsRequired();
        builder.Property(el => el.PaymentId).IsRequired();
        builder.HasOne(el => el.PaymentEntity).WithMany(el => el.Orders)
            .HasForeignKey(el => el.PaymentId);
        builder.Property(el => el.ShipperId).IsRequired();
        builder.HasOne(el => el.ShipperEntity).WithMany(el => el.Orders)
            .HasForeignKey(el => el.ShipperId).IsRequired();
        builder.Property(el => el.OrderNumber).ValueGeneratedOnAdd();
    }
}