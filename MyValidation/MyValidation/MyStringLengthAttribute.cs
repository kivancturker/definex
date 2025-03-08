namespace MyValidation;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class MyStringLengthAttribute : MyValidationAttribute
{
    public MyStringLengthAttribute(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
    }
    public int MinLength { get; set; }
    public int MaxLength { get; set; }
}