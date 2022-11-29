using Module4HW4.Repositories;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class CustomerService : ICustomerService
{
    private ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> CreateCustomer(string firstName, string lastName)
    {
        var id = await _customerRepository.AddCustomerAsync(firstName, lastName);

        return id;
    }
}