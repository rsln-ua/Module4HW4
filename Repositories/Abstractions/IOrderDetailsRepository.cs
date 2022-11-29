using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface IOrderDetailsRepository
{
    Task<int> AddOrderDetailsAsync(decimal price, decimal discount, int orderId, int productId);
    Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
    Task<bool> DeleteOrderDetailsByIdAsync(int id);
    Task<bool> UpdateOrderDetailsAsync(OrderDetails item);
}