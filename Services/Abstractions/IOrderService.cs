using Module4HW4.Models;

namespace Module4HW4.Services.Abstractions;

public interface IOrderService
{
    Task<int> CreateOrder(int customerId, int paymentId, int shipperId);
    Task<int?> MakeAnOrder(int customerId, int paymentId, int shipperId, List<OrderDetailsBar> items);
}