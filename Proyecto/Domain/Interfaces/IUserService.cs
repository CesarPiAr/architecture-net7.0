using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<UserOutput>> GetAllAsync();

        Task<List<UserOutput>> GetAllByOrganizationIdAsync(int id);

        Task<Usuario> GetByEmailAndPasswordAsync(string email, string password);

        Task<UserOutput> GetByIdAsync(int id);

        Task CreateAsync(UserInput user);

        Task UpdateAsync(UserInput user);

        Task DeleteAsync(int id);
    }
}
