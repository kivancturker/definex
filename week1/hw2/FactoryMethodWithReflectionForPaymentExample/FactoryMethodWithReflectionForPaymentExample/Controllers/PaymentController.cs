using FactoryMethodWithReflectionForPaymentExample.Models;
using FactoryMethodWithReflectionForPaymentExample.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FactoryMethodWithReflectionForPaymentExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPaymentFactory _paymentFactory;

    public PaymentController(AppDbContext context, IPaymentFactory paymentFactory)
    {
        _context = context;
        _paymentFactory = paymentFactory;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Payment>>> Get()
    {
        List<Payment> payments = await _context.Payments.ToListAsync();
        return Ok(payments);
    }

    [HttpPost]
    public async Task<ActionResult> AddPayment(Payment payment)
    {
        _context.Payments.Add(payment); 
        await _context.SaveChangesAsync();
        return Ok(payment);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> MakePayment(int paymentId)
    {
        Payment? payment = await _context.Payments.FindAsync(paymentId);
        if (payment == null)
        {
            return BadRequest("Payment not found");
        }
        
        try
        {
            var paymentProvider = _paymentFactory.CreatePayment(payment.PaymentClassName);
            string result = paymentProvider.MakePayment();
            return Ok(new { message = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}