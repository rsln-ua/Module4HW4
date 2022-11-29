using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;

namespace Module4HW4.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddProductAsync(string name, string description, decimal unitPrice, decimal discount, int categoryId, int supplierId)
    {
        var entity = new ProductEntity()
        { Name = name, Description = description, UnitPrice = unitPrice, Discount = discount, CategoryId = categoryId, SupplierId = supplierId };
        DbContext.Products.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var entity = await DbContext.Products.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Product>(entity);
    }

    public async Task<bool> DeleteProductByIdAsync(int id)
    {
        var entity = await DbContext.Products.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateProductAsync(Product item)
    {
        var entity = await DbContext.Products.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<ProductEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}