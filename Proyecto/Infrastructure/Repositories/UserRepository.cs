using Microsoft.EntityFrameworkCore;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;
using Proyecto.API.Infrastructure.Data;

namespace Proyecto.API.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly OrganizationDbContext _context;

        public UserRepository(OrganizationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<List<Usuario>> GetAllByOrganizationIdAsync(int id)
        {
            return await _context.Usuarios.Where(m => m.OrganizacionId == id).ToListAsync();
        }

        public async Task<Usuario> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Usuarios.Where(m=> m.Email == email && m.Password == password).Include(m => m.Organizacion).FirstAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task CreateAsync(Usuario user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
