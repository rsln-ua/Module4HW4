using Microsoft.Extensions.Logging;
using Module4HW4.Repositories;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class CustomerService : ICustomerService
{
    private ICustomerRepository _customerRepository;
    private ILogger<CustomerService> _loggerService;

    public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> loggerService)
    {
        _customerRepository = customerRepository;
        _loggerService = loggerService;
    }

    public async Task<int> CreateCustomer(string firstName, string lastName)
    {
        var id = await _customerRepository.AddCustomerAsync(firstName, lastName);
        _loggerService.LogInformation("Created customer with Id = {Id}", id);

        return id;
    }
}