using Microsoft.EntityFrameworkCore;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;
using Proyecto.API.Infrastructure.Data;

namespace Proyecto.API.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllByOrganizationIdAsync(int id)
        {
            return await _context.Productos.Where(m => m.OrganizacionId == id).ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task CreateAsync(Producto product)
        {
            _context.Productos.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var organizacion = await _context.Productos.FindAsync(id);
            if (organizacion != null)
            {
                _context.Productos.Remove(organizacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
