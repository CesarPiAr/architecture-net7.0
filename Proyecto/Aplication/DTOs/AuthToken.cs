namespace Proyecto.API.Aplication.DTOs
{
    public class AuthToken
    {
        public string AccessToken { get; set; }
        public List<string> SlugTenant { get; set; }
    }
}
