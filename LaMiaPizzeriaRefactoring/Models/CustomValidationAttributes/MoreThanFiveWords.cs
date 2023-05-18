using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeriaRefactoring.Models.CustomValidationAttributes
{
    public class MoreThanFiveWords : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().Split(" ").Length < 5)
            {
                return new ValidationResult("Il campo deve contenere almeno cinque parole");
            }

            return ValidationResult.Success;
        }
    }
}
