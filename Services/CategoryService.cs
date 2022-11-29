using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> CreateCategory(string name, string description)
    {
        var id = await _categoryRepository.AddCategoryAsync(name, description);

        return id;
    }

    public async Task<Category> GetCategory(int id)
    {
        var item = await _categoryRepository.GetCategoryByIdAsync(id);

        return item;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var result = await _categoryRepository.DeleteCategoryByIdAsync(id);

        return result;
    }

    public async Task<bool> UpdateCategory(Category item)
    {
        var result = await _categoryRepository.UpdateCategoryAsync(item);

        return result;
    }
}