using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private IOrderDetailsRepository _orderDetailsRepository;
    private IProductService _productService;

    public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IProductService productService)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _productService = productService;
    }

    public async Task<int> CreateOrderDetails(int orderId, int productId, decimal? discount = null)
    {
        var product = await _productService.GetProductById(productId);
        var id = await _orderDetailsRepository.AddOrderDetailsAsync(product.UnitPrice, orderId, productId, discount);

        return id;
    }
}