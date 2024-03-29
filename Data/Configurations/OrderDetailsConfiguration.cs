using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
    {
        builder.Property(el => el.Price).IsRequired();
        builder.Property(el => el.Discount).HasDefaultValue(0);
        builder.Property(el => el.ProductId).IsRequired();
        builder.HasOne(el => el.Product).WithMany(el => el.OrderDetails)
            .HasForeignKey(el => el.ProductId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Property(el => el.OrderId).IsRequired();
        builder.HasOne(el => el.Order).WithMany(el => el.OrderDetails)
            .HasForeignKey(el => el.OrderId).IsRequired();
        builder.Property(el => el.Quantity).HasDefaultValue(1);
    }
}