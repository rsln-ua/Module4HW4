using Module4HW4.Models;

namespace Module4HW4.Services.Abstractions;

public interface IOrderDetailsService
{
    Task<int> CreateOrderDetails(int orderId, int productId, int? quantity = null, decimal? discount = null);
}