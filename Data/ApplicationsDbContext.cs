using Microsoft.EntityFrameworkCore;
using Module4HW4.Data.Configurations;
using Module4HW4.Data.Entities;

namespace Module4HW4.Data;

public class ApplicationsDbContext : DbContext
{
    public ApplicationsDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    public DbSet<PaymentEntity> Payments { get; set; } = null!;
    public DbSet<OrderDetailsEntity> OrderDetails { get; set; } = null!;
    public DbSet<ShipperEntity> Shippers { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<SupplierEntity> Suppliers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ShippersConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
    }
}