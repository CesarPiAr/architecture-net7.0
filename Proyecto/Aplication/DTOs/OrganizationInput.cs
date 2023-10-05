using System.ComponentModel.DataAnnotations;

namespace Proyecto.API.Aplication.DTOs
{
    public class OrganizationInput : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string SlugTenant { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult(
                    "Name is not valid.",
                    new[] { nameof(Name) });
            }

            if (string.IsNullOrWhiteSpace(SlugTenant))
            {
                yield return new ValidationResult(
                    "SlugTenant is not valid.",
                    new[] { nameof(SlugTenant) });
            }
        }
    }
}
