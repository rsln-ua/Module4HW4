using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface IOrderDetailsRepository
{
    Task<int> AddOrderDetailsAsync(decimal price, int orderId, int productId, decimal? discount = null);
    Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
    Task<bool> DeleteOrderDetailsByIdAsync(int id);
    Task<bool> UpdateOrderDetailsAsync(OrderDetails item);
}