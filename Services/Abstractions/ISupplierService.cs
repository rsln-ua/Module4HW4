using Module4HW4.Models;

namespace Module4HW4.Services.Abstractions;

public interface ISupplierService
{
    Task<int> CreateSupplier(string companyName, string firstName, string lastName, int customerId);
}