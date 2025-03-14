using MyValidation;

namespace MyValidationTestConsole;

public class Student
{
    [MyRequired]
    [MyStringLength(maxLength: 10, minLength: 5)]
    public string FirstName = "Johnaasdasdas";
    [MyRequired]
    public string LastName;
    [MyRequired]
    public int Age;
}