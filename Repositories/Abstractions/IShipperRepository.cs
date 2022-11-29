using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface IShipperRepository
{
    Task<bool> DeleteShipperByIdAsync(int id);
    Task<bool> UpdateShipperAsync(Shipper item);
    Task<Shipper> GetShipperByIdAsync(int id);
    Task<int> AddShipperAsync(string companyName, string phone);
}