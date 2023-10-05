using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IJwtService
    {
        AuthToken GenerateJwt(Usuario user);
    }
}
