using System.ComponentModel.DataAnnotations;

namespace LemonadeStand.Shared.Models
{
    public class LemonadeTypeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!value.ToString().ToLower().Contains("select lemonade") || value== null)
            {
                return null;
            }

            return new ValidationResult("You must pick a lemonade flawor",
                new[] { validationContext.MemberName });
        }
    }
}
