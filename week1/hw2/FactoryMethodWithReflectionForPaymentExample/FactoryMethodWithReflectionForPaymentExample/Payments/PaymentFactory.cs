using System.Reflection;
using FactoryMethodWithReflectionForPaymentExample.Payments.Interfaces;

namespace FactoryMethodWithReflectionForPaymentExample.Payments;

public class PaymentFactory : IPaymentFactory
{
    public IPayment CreatePayment(string paymentTypeName)
    {
        var paymentProvider = (IPayment) Assembly.GetAssembly(typeof(IPayment)).CreateInstance("FactoryMethodWithReflectionForPaymentExample.Payments." + paymentTypeName);
        if (paymentProvider == null)
        {
            throw new Exception("Payment " + paymentTypeName + " not found");
        }
        return paymentProvider;
    }
}