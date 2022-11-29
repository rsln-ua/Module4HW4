using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class ShipperService : IShipperService
{
    private IShipperRepository _shipperRepository;

    public ShipperService(IShipperRepository shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    public async Task<int> CreateShipper(string name, string phone)
    {
        var id = await _shipperRepository.AddShipperAsync(name, phone);

        return id;
    }
}