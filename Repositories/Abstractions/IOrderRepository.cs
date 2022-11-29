using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface IOrderRepository
{
    Task<bool> DeleteOrderByIdAsync(int id);
    Task<bool> UpdateOrderAsync(Order item);
    Task<Order> GetOrderByIdAsync(int id);
    Task<int> AddOrderAsync(int customerId, int paymentId, int shipperId, int? orderNumber, DateTime? orderDate, DateTime? shipDate);
}