using Module4HW4.Models;

namespace Module4HW4.Repositories.Abstractions;

public interface IPaymentRepository
{
    Task<bool> DeletePaymentByIdAsync(int id);
    Task<bool> UpdatePaymentAsync(Payment item);
    Task<Payment> GetPaymentByIdAsync(int id);
    Task<int> AddPaymentAsync(string type, bool allowed);
}