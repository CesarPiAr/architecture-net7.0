using Proyecto.API.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.API.Aplication.DTOs
{
    public class LoginInput : IValidatableObject
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (!EmailUtils.IsValidEmail(Email))
            {
                yield return new ValidationResult(
                    "El campo Email debe ser un correo electrónico válido.",
                    new[] { nameof(Email) });
            }

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
            {
                yield return new ValidationResult(
                    "El campo Password no es válido.",
                    new[] { nameof(Email) });
            }
        }
    }
}
