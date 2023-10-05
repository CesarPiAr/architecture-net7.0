using Proyecto.API.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.API.Aplication.DTOs
{
    public class ProductInput : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int OrganizacionId { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (OrganizacionId <= 0)
            {
                yield return new ValidationResult(
                    "OrganizacionId is not valid.",
                    new[] { nameof(OrganizacionId) });
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult(
                    "Name is not valid.",
                    new[] { nameof(Name) });
            }
        }
    }
}
