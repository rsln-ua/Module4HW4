using Module4HW4.Models;

namespace Module4HW4.Services.Abstractions;

public interface IPaymentService
{
   Task<int> CreatePayment(string? type = null);
}