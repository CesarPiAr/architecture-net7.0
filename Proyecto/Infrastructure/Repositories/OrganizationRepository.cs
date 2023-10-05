using Microsoft.EntityFrameworkCore;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;
using Proyecto.API.Infrastructure.Data;

namespace Proyecto.API.Infrastructure.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly OrganizationDbContext _context;

        public OrganizationRepository(OrganizationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Organizacion>> GetAllAsync()
        {
            return await _context.Organizaciones.ToListAsync();
        }

        public async Task<Organizacion> GetByIdAsync(int id)
        {
            return await _context.Organizaciones.FindAsync(id);
        }

        public async Task<Organizacion> GetByTenantAsync(string tenant)
        {
            return await _context.Organizaciones.Where(m => m.SlugTenant == tenant).FirstAsync();
        }

        public async Task<bool> AnyByTenantAsync(string tenant)
        {
            if (string.IsNullOrWhiteSpace(tenant)) 
            {
                return false;
            }
            return await _context.Organizaciones.AnyAsync(m => m.SlugTenant == tenant);
        }

        public async Task CreateAsync(Organizacion organizacion)
        {
            _context.Organizaciones.Add(organizacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organizacion organizacion)
        {
            _context.Entry(organizacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var organizacion = await _context.Organizaciones.FindAsync(id);
            if (organizacion != null)
            {
                _context.Organizaciones.Remove(organizacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
