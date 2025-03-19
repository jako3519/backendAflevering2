using System.ComponentModel.DataAnnotations;

namespace ExperienceAPI.Validators
{
    public class NonNegativePriceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int price && price < 0)
            {
                return new ValidationResult("Price cannot and must not negative. try again lil bro");
            }
            return ValidationResult.Success;
        }
    }
}