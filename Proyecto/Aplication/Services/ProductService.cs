using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;

namespace Proyecto.API.Aplication.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductOutput>> GetAllByOrganizationIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            var list = await _productRepository.GetAllByOrganizationIdAsync(id);
            return list.Select(m => new ProductOutput { Id = m.Id, Name = m.Name, OrganizacionId = m.OrganizacionId }).ToList();
        }

        public async Task<ProductOutput> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            var product = await _productRepository.GetByIdAsync(id);
            return new ProductOutput { Id = product.Id, Name = product.Name, OrganizacionId = product.OrganizacionId };
        }

        public async Task CreateAsync(ProductInput product)
        {
            await _productRepository.CreateAsync(new Producto { Id = product.Id, Name = product.Name, OrganizacionId = product.OrganizacionId });
        }

        public async Task UpdateAsync(ProductInput product)
        {
            await _productRepository.UpdateAsync(new Producto { Id = product.Id, Name = product.Name, OrganizacionId = product.OrganizacionId });
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            await _productRepository.DeleteAsync(id);
        }
    }
}
