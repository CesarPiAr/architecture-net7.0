namespace Proyecto.API.Domain.Entities
{
    public class Organizacion
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string SlugTenant { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
