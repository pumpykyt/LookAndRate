using LookAndRate.DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LookAndRate.API_Angular.Helper
{
    public class CustomEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value != null)
            {
                var service = (UserManager<User>)validationContext
                         .GetService(typeof(UserManager<User>));


                var user = service.FindByEmailAsync(value.ToString())
                    .Result;

                if (user != null)
                {
                    return new ValidationResult(null);
                }
                return ValidationResult.Success;
            }
            return new ValidationResult(null);
        }
    }
}
