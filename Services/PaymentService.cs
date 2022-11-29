using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class PaymentService : IPaymentService
{
    private IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<int> CreatePayment(string? type = null)
    {
        var id = await _paymentRepository.AddPaymentAsync(type);

        return id;
    }
}