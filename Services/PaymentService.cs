using Microsoft.Extensions.Logging;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;

namespace Module4HW4.Services;

public class PaymentService : IPaymentService
{
    private IPaymentRepository _paymentRepository;
    private ILogger<PaymentService> _loggerService;

    public PaymentService(IPaymentRepository paymentRepository, ILogger<PaymentService> loggerService)
    {
        _paymentRepository = paymentRepository;
        _loggerService = loggerService;
    }

    public async Task<int> CreatePayment(string? type = null)
    {
        var id = await _paymentRepository.AddPaymentAsync(type);
        _loggerService.LogInformation("Created payment with Id = {Id}", id);

        return id;
    }
}