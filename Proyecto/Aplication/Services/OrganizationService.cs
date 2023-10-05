using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;

namespace Proyecto.API.Aplication.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository) 
        {
            _organizationRepository = organizationRepository;
        }
        public async Task<List<OrganizationOutput>> GetAllAsync()
        {
            var list = await _organizationRepository.GetAllAsync();
            return list.Select(m => new OrganizationOutput { Id = m.Id, Name = m.Name, SlugTenant = m.SlugTenant }).ToList();
        }

        public async Task<OrganizationOutput> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            var result = await _organizationRepository.GetByIdAsync(id);
            return new OrganizationOutput { Id = result.Id, Name = result.Name, SlugTenant = result.SlugTenant };
        }

        public async Task<OrganizationOutput> GetByTenantAsync(string tenant)
        {
            if (string.IsNullOrWhiteSpace(tenant))
            {
                throw new Exception("tenant is not valid");
            }
            var result = await _organizationRepository.GetByTenantAsync(tenant);
            return new OrganizationOutput { Id = result.Id, Name = result.Name, SlugTenant = result.SlugTenant };
        }

        public async Task<bool> AnyByTenantAsync(string tenant)
        {
            if (string.IsNullOrWhiteSpace(tenant))
            {
                return false;
            }
            return await _organizationRepository.AnyByTenantAsync(tenant);
        }

        public async Task CreateAsync(OrganizationInput organization)
        {
            await _organizationRepository.CreateAsync(new Organizacion { Id = organization.Id, Name = organization.Name, SlugTenant = organization.SlugTenant });
        }

        public async Task UpdateAsync(OrganizationInput organization)
        {
            await _organizationRepository.UpdateAsync(new Organizacion { Id = organization.Id, Name = organization.Name, SlugTenant = organization.SlugTenant });
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) 
            {
                throw new Exception("Id is not valid");
            }
            await _organizationRepository.DeleteAsync(id);
        }
    }
}
