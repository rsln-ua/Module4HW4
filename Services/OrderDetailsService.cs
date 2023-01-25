using Microsoft.Extensions.Logging;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private IOrderDetailsRepository _orderDetailsRepository;
    private IProductService _productService;
    private ILogger<OrderDetailsService> _loggerService;

    public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IProductService productService, ILogger<OrderDetailsService> loggerService)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _productService = productService;
        _loggerService = loggerService;
    }

    public async Task<int> CreateOrderDetails(int orderId, int productId, int? quantity = null, decimal? discount = null)
    {
        var product = await _productService.GetProductById(productId);
        var id = await _orderDetailsRepository.AddOrderDetailsAsync(product.UnitPrice, orderId, productId, quantity, discount);
        _loggerService.LogInformation("Created order details with Id = {Id}", id);

        return id;
    }
}