namespace FactoryMethodWithReflectionForPaymentExample.Payments.Interfaces;

public interface IPaymentFactory
{
    IPayment CreatePayment(string paymentTypeName);
}