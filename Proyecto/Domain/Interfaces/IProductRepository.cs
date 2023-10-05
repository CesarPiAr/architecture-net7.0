using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Producto>> GetAllByOrganizationIdAsync(int id);

       Task<Producto> GetByIdAsync(int id);

        Task CreateAsync(Producto product);

        Task UpdateAsync(Producto product);

        Task DeleteAsync(int id);
    }
}
