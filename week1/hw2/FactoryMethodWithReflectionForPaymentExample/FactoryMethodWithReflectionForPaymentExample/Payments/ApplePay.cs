using FactoryMethodWithReflectionForPaymentExample.Payments.Interfaces;

namespace FactoryMethodWithReflectionForPaymentExample.Payments;

public class ApplePay : IPayment
{
    public string MakePayment()
    {
        return "Payment made with ApplePay";
    }
}