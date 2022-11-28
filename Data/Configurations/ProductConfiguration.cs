using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.Property(el => el.Name).IsRequired();
        builder.Property(el => el.Description).IsRequired();
        builder.Property(el => el.UnitPrice).IsRequired();
        builder.Property(el => el.Discount).HasDefaultValue(0);
        builder.Property(el => el.CategoryId).IsRequired();
        builder.HasOne(el => el.CategoryEntity).WithMany(el => el.Products)
            .HasForeignKey(el => el.CategoryId).IsRequired();
        builder.Property(el => el.SupplierId).IsRequired();
        builder.HasOne(el => el.SupplierEntity).WithMany(el => el.Products)
            .HasForeignKey(el => el.SupplierId).IsRequired();
    }
}