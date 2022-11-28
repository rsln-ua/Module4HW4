using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.Property(el => el.FirstName).IsRequired();
        builder.Property(el => el.LastName).IsRequired();
        builder.HasMany(el => el.Orders).WithOne(el => el.CustomerEntity)
            .HasForeignKey(el => el.CustomerId).IsRequired();
    }
}