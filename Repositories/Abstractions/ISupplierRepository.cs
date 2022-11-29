using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface ISupplierRepository
{
    Task<bool> DeleteSupplierByIdAsync(int id);
    Task<bool> UpdateSupplierAsync(Supplier item);
    Task<Supplier> GetSupplierByIdAsync(int id);
    Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, string email, string phone, int customerId);
}