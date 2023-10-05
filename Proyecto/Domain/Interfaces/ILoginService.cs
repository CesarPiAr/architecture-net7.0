using Proyecto.API.Aplication.DTOs;

namespace Proyecto.API.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<AuthToken> ExecuteAsync(LoginInput request);
    }
}
