using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class OrderService : IOrderService
{
    private ApplicationDbContext _dbContext;
    private IOrderRepository _orderRepository;
    private IOrderDetailsService _orderDetailsService;

    public OrderService(IOrderRepository orderRepository, ApplicationDbContext dbContext, IOrderDetailsService orderDetailsService)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
        _orderDetailsService = orderDetailsService;
    }

    public async Task<int> CreateOrder(int customerId, int paymentId, int shipperId)
    {
        var timestamp = DateTime.UtcNow;
        var id = await _orderRepository.AddOrderAsync(customerId, paymentId, shipperId, timestamp);

        return id;
    }

    public async Task<int?> MakeAnOrder(int customerId, int paymentId, int shipperId, List<OrderDetailsBar> items)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var id = await CreateOrder(customerId, paymentId, shipperId);

            foreach (var el in items)
            {
                // FIXME: save to db only first record.
                _ = await _orderDetailsService.CreateOrderDetails(id, el.ProductId, el.Discount);
            }

            await transaction.CommitAsync();
            return id;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }
}