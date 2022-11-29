using Module4HW4.Models;

namespace Module4HW4.Services.Abstractions;

public interface ICustomerService
{
    Task<int> CreateCustomer(string firstName, string lastName);
    Task<Customer> GetCustomer(int id);
    Task<Customer> GetCustomerWithOrders(int id);
}