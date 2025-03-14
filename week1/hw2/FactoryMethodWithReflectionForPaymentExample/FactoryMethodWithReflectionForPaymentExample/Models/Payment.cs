using System.ComponentModel.DataAnnotations;

namespace FactoryMethodWithReflectionForPaymentExample.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string PaymentName { get; set; }
    [Required]
    public string PaymentClassName { get; set; }
}