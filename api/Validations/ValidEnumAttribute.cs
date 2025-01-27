using System;
using System.ComponentModel.DataAnnotations;

public class ValidEnumAttribute : ValidationAttribute
{
    private readonly Type _enumType;

    public ValidEnumAttribute(Type enumType)
    {
        if (!enumType.IsEnum)
            throw new ArgumentException("O tipo fornecido deve ser um Enum.");
        _enumType = enumType;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            return new ValidationResult("Este campo é obrigatório.");

        if (Enum.TryParse(_enumType, value.ToString(), true, out _))
            return ValidationResult.Success;

        return new ValidationResult(ErrorMessage ?? "O valor fornecido não é válido.");
    }
}