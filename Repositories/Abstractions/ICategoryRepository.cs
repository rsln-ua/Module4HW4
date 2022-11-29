using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface ICategoryRepository
{
    Task<int> AddCategoryAsync(string name, string description);
    Task<Category> GetCategoryByIdAsync(int id);
    Task<bool> DeleteCategoryByIdAsync(int id);
    Task<bool> UpdateCategoryAsync(Category item);
}