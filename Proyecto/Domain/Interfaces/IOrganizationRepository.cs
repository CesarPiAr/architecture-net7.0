using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<List<Organizacion>> GetAllAsync();
        Task<Organizacion> GetByIdAsync(int id);
        Task<Organizacion> GetByTenantAsync(string tenant);
        Task<bool> AnyByTenantAsync(string tenant);
        Task CreateAsync(Organizacion organizacion);
        Task UpdateAsync(Organizacion organizacion);
        Task DeleteAsync(int id);
    }
}
