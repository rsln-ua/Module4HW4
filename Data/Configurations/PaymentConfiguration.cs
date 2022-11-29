using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.Property(el => el.Type).HasDefaultValue("SomeDefaultValue");
        builder.Property(el => el.Allowed).IsRequired();
        builder.HasMany(el => el.Orders).WithOne(el => el.PaymentEntity)
            .HasForeignKey(el => el.PaymentId).IsRequired();
    }
}