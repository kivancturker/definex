using FactoryMethodWithReflectionForPaymentExample.Payments.Interfaces;

namespace FactoryMethodWithReflectionForPaymentExample.Payments;

public class GooglePay : IPayment
{
    public string MakePayment()
    {
        return "Payment made with GooglePay";
    }
}