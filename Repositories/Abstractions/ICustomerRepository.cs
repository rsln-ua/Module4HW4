using Module4HW4.Models;

namespace Module4HW4.Repositories;

public interface ICustomerRepository
{
    Task<int> AddCustomerAsync(string firstName, string lastName, string? email, string? phone);
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<bool> DeleteCustomerByIdAsync(int id);
    Task<bool> UpdateCustomerAsync(Customer item);
}