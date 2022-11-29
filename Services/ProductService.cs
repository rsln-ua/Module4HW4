using Microsoft.Extensions.Logging;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private ILogger<ProductService> _loggerService;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> loggerService)
    {
        _productRepository = productRepository;
        _loggerService = loggerService;
    }

    public async Task<int> CreateProduct(
        string name,
        string description,
        decimal unitPrice,
        decimal discount,
        int categoryId,
        int supplierId)
    {
        var id = await _productRepository.AddProductAsync(name, description, unitPrice, discount, categoryId, supplierId);
        _loggerService.LogInformation("Created product with Id = {Id}", id);

        return id;
    }

    public async Task<Product> GetProductById(int id)
    {
        var item = await _productRepository.GetProductByIdAsync(id);

        if (item == null)
        {
            _loggerService.LogWarning("Not founded product with Id = {Id}", id);
        }

        return item!;
    }
}