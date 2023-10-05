using Proyecto.API.Aplication.DTOs;

namespace Proyecto.API.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductOutput>> GetAllByOrganizationIdAsync(int id);

        Task<ProductOutput> GetByIdAsync(int id);

        Task CreateAsync(ProductInput product);

        Task UpdateAsync(ProductInput product);

        Task DeleteAsync(int id);
    }
}
