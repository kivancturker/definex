using MyValidation;

namespace MyValidationTestConsole;

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student();
        MyValidationResult studentValidationResult = MyValidationUtil.Validate(student);
        if (studentValidationResult.IsValid)
        {
            Console.WriteLine("Student is valid");
        }
        else
        {
            studentValidationResult.Errors.ForEach(Console.WriteLine);
        }
    
    }
}