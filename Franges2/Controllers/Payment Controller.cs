using Microsoft.AspNetCore.Mvc;

namespace Franges2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    public interface IPaymentService
    {
    }

    private readonly IPaymentService _paymentService;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
    {
        _paymentService = paymentService;
        _logger = logger;
    }

    // GET: api/payment/methods
    [HttpGet("methods")]
    public ActionResult GetPaymentMethods()
    {
        var methods = new[]
        {
            new { Id = "card", Name = "Банковская карта" },
            new { Id = "yoomoney", Name = "ЮMoney" },
            new { Id = "sbp", Name = "СБП" },
            new { Id = "qiwi", Name = "QIWI" }
        };

        return Ok(methods);
    }
};