using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetAllAsync();

        Task<List<Usuario>> GetAllByOrganizationIdAsync(int id);

        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetByEmailAndPasswordAsync(string email, string password);

        Task CreateAsync(Usuario user);

        Task UpdateAsync(Usuario user);

        Task DeleteAsync(int id);
    }
}
