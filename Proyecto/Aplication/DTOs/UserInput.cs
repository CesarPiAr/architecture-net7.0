using Proyecto.API.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.API.Aplication.DTOs
{
    public class UserInput : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (!EmailUtils.IsValidEmail(Email))
            {
                yield return new ValidationResult(
                    "Email is not valid.",
                    new[] { nameof(Email) });
            }

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
            {
                yield return new ValidationResult(
                    "Password is not valid.",
                    new[] { nameof(Password) });
            }

            if (OrganizationId <= 0)
            {
                yield return new ValidationResult(
                    "OrganizationId is not valid.",
                    new[] { nameof(OrganizationId) });
            }
        }
    }
}
