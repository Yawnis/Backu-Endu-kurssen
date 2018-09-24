using System;
using System.ComponentModel.DataAnnotations;

namespace Teht2
{
    public class DateTypeLeglessAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime time = (DateTime)value;
            
            if (time < System.DateTime.Now) 
            {
                return ValidationResult.Success;
            } else 
            {
                return new ValidationResult("There is no time");
            }
        }
    }
}