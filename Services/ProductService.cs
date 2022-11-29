using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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

        return id;
    }

    public async Task<Product> GetProductById(int id)
    {
        var item = await _productRepository.GetProductByIdAsync(id);

        return item;
    }
}