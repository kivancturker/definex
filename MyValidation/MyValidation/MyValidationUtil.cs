using System.Reflection;

namespace MyValidation;

public static class MyValidationUtil
{
    public static MyValidationResult Validate(object entityToVerify)
    {
        List<string> errorMessage = new List<string>();
        bool isValid = true;
        // Get all the fields with marked as MyValidationAttribute
        List<FieldInfo> fields = GetFieldsWithMyValidtationAttribute(entityToVerify);
        // Iterate on the fields with MyValidationAttribute
        foreach (FieldInfo field in fields)
        {
            // Check for each MyValidationAttribute type
            List<object> validationAttributes = field.GetCustomAttributes(typeof(MyValidationAttribute), true).ToList();

            var fieldValue = field.GetValue(entityToVerify);
            Type? fieldValueType = fieldValue?.GetType();
            
            // Check if valid according to its validation rule
            foreach (var validationAttribute in validationAttributes)
            {
                if (validationAttribute is MyRequiredAttribute)
                {
                    if (fieldValue == null || 
                        (fieldValueType == typeof(string) && string.IsNullOrEmpty(fieldValue?.ToString())))
                    {
                        isValid = false;
                        errorMessage.Add("Field '" + field.Name + "' cannot be empty or null.");
                    }
                }
                else if (validationAttribute is MyStringLengthAttribute)
                {
                    MyStringLengthAttribute stringLengthAttribute = validationAttribute as MyStringLengthAttribute;
                    if (fieldValue == null || string.IsNullOrEmpty(fieldValue?.ToString()))
                    {
                        isValid = false;
                        errorMessage.Add("Field '" + field.Name + "' cannot be empty or null.");
                    }
                    else if (fieldValueType == typeof(string) &&
                             fieldValue?.ToString().Length > stringLengthAttribute?.MaxLength)
                    {
                        isValid = false;
                        errorMessage.Add("Field" + field.Name + " cannot be longer than " + stringLengthAttribute.MaxLength + ".");
                    }
                    else if (fieldValueType == typeof(string) &&
                             fieldValue?.ToString().Length < stringLengthAttribute?.MinLength)
                    {
                        isValid = false;
                        errorMessage.Add("Field" + field.Name + " cannot be shorter than " + stringLengthAttribute.MinLength + ".");
                    }
                }
            }
        }
        
        return new MyValidationResult(isValid, errorMessage);
    }

    private static List<FieldInfo> GetFieldsWithMyValidtationAttribute(object entityToVerify)
    {
        Type entityType = entityToVerify.GetType();
        List<FieldInfo> fields = entityType.GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Where(f => f.GetCustomAttributes(typeof(MyValidationAttribute), true).Length > 0)
            .ToList();
        return fields;
    }
}