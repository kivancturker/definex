namespace MyValidation;

// It indicates that field is Non-null and not empty
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class MyRequiredAttribute : MyValidationAttribute
{
    
}