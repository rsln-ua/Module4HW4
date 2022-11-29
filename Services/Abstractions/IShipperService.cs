using Module4HW4.Models;

namespace Module4HW4.Services.Abstractions;

public interface IShipperService
{
   Task<int> CreateShipper(string name, string phone);
}