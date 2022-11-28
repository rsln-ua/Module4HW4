using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(el => el.Type).IsRequired();
        builder.Property(el => el.Allowed).IsRequired();
        builder.HasMany(el => el.Orders).WithOne(el => el.Payment)
            .HasForeignKey(el => el.PaymentId).IsRequired();
    }
}