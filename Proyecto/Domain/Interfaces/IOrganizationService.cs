using Proyecto.API.Aplication.DTOs;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<OrganizationOutput>> GetAllAsync();
        Task<OrganizationOutput> GetByIdAsync(int id);
        Task<OrganizationOutput> GetByTenantAsync(string tenant);
        Task<bool> AnyByTenantAsync(string tenant);
        Task CreateAsync(OrganizationInput organizacion);
        Task UpdateAsync(OrganizationInput organizacion);
        Task DeleteAsync(int id);
    }
}
