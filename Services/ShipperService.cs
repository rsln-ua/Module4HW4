using Microsoft.Extensions.Logging;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class ShipperService : IShipperService
{
    private IShipperRepository _shipperRepository;
    private ILogger<ShipperService> _loggerService;

    public ShipperService(IShipperRepository shipperRepository, ILogger<ShipperService> loggerService)
    {
        _shipperRepository = shipperRepository;
        _loggerService = loggerService;
    }

    public async Task<int> CreateShipper(string name, string phone)
    {
        var id = await _shipperRepository.AddShipperAsync(name, phone);
        _loggerService.LogInformation("Created shipper with Id = {Id}", id);

        return id;
    }
}