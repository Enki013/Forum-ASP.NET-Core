using System;
using System.ComponentModel.DataAnnotations;

public class RequiredIfAttribute : ValidationAttribute
{
    private readonly string _propertyName;
    private readonly object _desiredValue;

    public RequiredIfAttribute(string propertyName, object desiredValue)
    {
        _propertyName = propertyName;
        _desiredValue = desiredValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(_propertyName);
        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var propertyValue = property.GetValue(validationContext.ObjectInstance);

        if (propertyValue?.ToString() == _desiredValue.ToString() && value == null)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}