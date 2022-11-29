using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;

namespace Module4HW4.Repositories;

public class OrderDetailsRepository : BaseRepository, IOrderDetailsRepository
{
    public OrderDetailsRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddOrderDetailsAsync(decimal price, int orderId, int productId, decimal? discount = null)
    {
        var entity = new OrderDetailsEntity()
            { Price = price, OrderId = orderId, ProductId = productId };

        if (discount != null)
        {
            entity.Discount = discount.GetValueOrDefault();
        }

        DbContext.OrderDetails.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
    {
        var entity = await DbContext.OrderDetails.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<OrderDetails>(entity);
    }

    public async Task<bool> DeleteOrderDetailsByIdAsync(int id)
    {
        var entity = await DbContext.OrderDetails.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateOrderDetailsAsync(OrderDetails item)
    {
        var entity = await DbContext.OrderDetails.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<OrderDetailsEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}