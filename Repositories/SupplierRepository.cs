using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;

namespace Module4HW4.Repositories;

public class SupplierRepository : BaseRepository, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, string email, string phone, int customerId)
    {
        var entity = new SupplierEntity()
        {
            CompanyName = companyName, ContactFName = contactFName, ContactLName = contactLName,
            Email = email, CustomerId = customerId, Phone = phone
        };
        DbContext.Suppliers.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Supplier> GetSupplierByIdAsync(int id)
    {
        var entity = await DbContext.Suppliers.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Supplier>(entity);
    }

    public async Task<bool> DeleteSupplierByIdAsync(int id)
    {
        var entity = await DbContext.Suppliers.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateSupplierAsync(Supplier item)
    {
        var entity = await DbContext.Suppliers.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<SupplierEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}