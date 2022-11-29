using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;

namespace Module4HW4.Repositories;

public class PaymentRepository : BaseRepository, IPaymentRepository
{
    public PaymentRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddPaymentAsync(string type, bool allowed)
    {
        var entity = new PaymentEntity() { Type = type, Allowed = allowed };
        DbContext.Payments.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        var entity = await DbContext.Payments.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Payment>(entity);
    }

    public async Task<bool> DeletePaymentByIdAsync(int id)
    {
        var entity = await DbContext.Payments.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdatePaymentAsync(Payment item)
    {
        var entity = await DbContext.Payments.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<PaymentEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}