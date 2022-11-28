using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(el => el.CustomerId).IsRequired();
        builder.HasOne(el => el.Customer).WithMany(el => el.Orders)
            .HasForeignKey(el => el.CustomerId).IsRequired();
        builder.Property(el => el.PaymentId).IsRequired();
        builder.HasOne(el => el.Payment).WithMany(el => el.Orders)
            .HasForeignKey(el => el.PaymentId);
        builder.Property(el => el.ShipperId).IsRequired();
        builder.HasOne(el => el.Shipper).WithMany(el => el.Orders)
            .HasForeignKey(el => el.ShipperId).IsRequired();
    }
}