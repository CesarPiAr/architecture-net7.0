namespace Proyecto.API.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int OrganizacionId { get; set; }
        public Organizacion Organizacion { get; set; }
    }
}
