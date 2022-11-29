using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class SupplierService : ISupplierService
{
    private ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<int> CreateSupplier(string companyName, string firstName, string lastName, int customerId)
    {
        var id = await _supplierRepository.AddSupplierAsync(companyName, firstName, lastName, customerId);

        return id;
    }
}