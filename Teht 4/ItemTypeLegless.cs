using System.ComponentModel.DataAnnotations;

namespace Teht2
{
    public class ItemTypeLeglessAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string ItemType = value as string;
            
            if (ItemType == "Sword") 
            {
                return ValidationResult.Success;
            }
            else if (ItemType == "Bow") 
            {
                return ValidationResult.Success;
            }
            else if (ItemType == "Axe") 
            {
                return ValidationResult.Success;
            } else 
            {
                return new ValidationResult("That's not a valid weapon in Vantaa!");
            }
        }
    }
}