namespace Proyecto.API.Infrastructure.Configuration
{
    public class JwtSettings
    {
        public string AccessTokenSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenDurationInMinutes { get; set; }
    }
}
