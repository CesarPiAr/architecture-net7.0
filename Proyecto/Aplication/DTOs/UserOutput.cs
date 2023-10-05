using System.ComponentModel.DataAnnotations;

namespace Proyecto.API.Aplication.DTOs
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int OrganizationId { get; set; }
    }
}
