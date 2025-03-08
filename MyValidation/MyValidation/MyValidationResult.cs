namespace MyValidation;

public class MyValidationResult
{
    public bool IsValid { get; }
    public List<string> Errors { get; }

    public MyValidationResult(bool isValid, List<string> errors)
    {
        IsValid = isValid;
        Errors = errors;
    }
}