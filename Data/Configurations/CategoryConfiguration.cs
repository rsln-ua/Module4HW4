using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(el => el.Name).IsRequired();
        builder.Property(el => el.Description).IsRequired();
        builder.Property(el => el.Active).HasDefaultValue(true);
        builder.HasMany(el => el.Products).WithOne(el => el.Category)
            .HasForeignKey(el => el.CategoryId).IsRequired();
    }
}