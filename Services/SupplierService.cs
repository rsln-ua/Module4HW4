using Microsoft.Extensions.Logging;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class SupplierService : ISupplierService
{
    private ISupplierRepository _supplierRepository;
    private ILogger<SupplierService> _loggerService;

    public SupplierService(ISupplierRepository supplierRepository, ILogger<SupplierService> loggerService)
    {
        _supplierRepository = supplierRepository;
        _loggerService = loggerService;
    }

    public async Task<int> CreateSupplier(string companyName, string firstName, string lastName, int customerId)
    {
        var id = await _supplierRepository.AddSupplierAsync(companyName, firstName, lastName, customerId);
        _loggerService.LogInformation("Created supplier with Id = {Id}", id);

        return id;
    }
}