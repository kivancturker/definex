using System.Reflection;
using FactoryMethodWithReflectionForPaymentExample.Payments.Interfaces;

namespace FactoryMethodWithReflectionForPaymentExample.Payments;

public class PaymentFactory : IPaymentFactory
{
    public IPayment CreatePayment(string paymentTypeName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        string fullTypeName = $"FactoryMethodWithReflectionForPaymentExample.Payments.{paymentTypeName}";
        
        Type? paymentType = assembly.GetType(fullTypeName);
        
        if (paymentType == null)
        {
            throw new Exception($"Payment type '{paymentTypeName}' not found");
        }
        
        if (!typeof(IPayment).IsAssignableFrom(paymentType))
        {
            throw new Exception($"Payment type '{paymentTypeName}' does not implement IPayment interface");
        }
        
        var paymentProvider = (IPayment) Activator.CreateInstance(paymentType)!;
            
        return paymentProvider;
    }
}