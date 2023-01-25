using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    private ILogger<OrderService> _loggerService;

    public OrderService(IOrderRepository orderRepository, ApplicationDbContext dbContext, IOrderDetailsService orderDetailsService, ILogger<OrderService> loggerService)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
        _orderDetailsService = orderDetailsService;
        _loggerService = loggerService;
    }

    public async Task<int> CreateOrder(int customerId, int paymentId, int shipperId)
    {
        var timestamp = DateTime.UtcNow;
        var id = await _orderRepository.AddOrderAsync(customerId, paymentId, shipperId, timestamp);
        _loggerService.LogInformation("Created order with Id = {Id}", id);

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
                await _orderDetailsService.CreateOrderDetails(id, el.ProductId, el.Quantity, el.Discount);
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

    public async Task<Order> GetOrderById(int id)
    {
        var item = await _orderRepository.GetOrderByIdAsync(id);

        return item;
    }

    public async Task<Order> GetFullOrderById(int id)
    {
        var item = await _orderRepository.GetFullOrderByIdAsync(id);

        return item;
    }
}