using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Interfaces;
using Proyecto.API.Filters;
using System.Net;

namespace Proyecto.API.Controllers
{
    [Route("api/{slugTenant}/Products")]
    [ApiController]
    [ValidateTenant]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IProductService _productService;
        public ProductController(IOrganizationService organizationService, IProductService productService) 
        {
            _organizationService = organizationService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ResponseApi<List<ProductOutput>>> Get(string slugTenant)
        {
            var result = new ResponseApi<List<ProductOutput>>();
            result.Status = HttpStatusCode.OK;
            try
            {
                var organization = await _organizationService.GetByTenantAsync(slugTenant);
                result.Data = await _productService.GetAllByOrganizationIdAsync(organization.Id);
            }
            catch (Exception ex) 
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ResponseApi<ProductOutput>> Get(string slugTenant, int id)
        {
            var result = new ResponseApi<ProductOutput>();
            result.Status = HttpStatusCode.OK;
            try
            {
                var organization = await _organizationService.GetByTenantAsync(slugTenant);
                result.Data = await _productService.GetByIdAsync(id);

                if (result.Data.OrganizacionId != organization.Id) 
                {
                    throw new Exception("tenant or id is not valid");
                }
            }
            catch (Exception ex)
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }

            return result;
        }

        [HttpPost]
        public async Task<ResponseApi<bool>> Post(string slugTenant, [FromBody]  ProductInput product)
        {
            var result = new ResponseApi<bool>();
            result.Status = HttpStatusCode.OK;
            result.Data = false;
            try
            {
                var organization = await _organizationService.GetByTenantAsync(slugTenant);

                if (product.OrganizacionId != organization.Id)
                {
                    throw new Exception("tenant or id is not valid");
                }

                await _productService.CreateAsync(product);
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ResponseApi<int>> Put(string slugTenant, int id, [FromBody] ProductInput product)
        {
            if (id == product.Id)
            {
                await _productService.UpdateAsync(product);
                return new ResponseApi<int> { Status = HttpStatusCode.OK, Data = id };
            }
            return new ResponseApi<int> { Status = HttpStatusCode.Conflict, StatusText = "Id is not valid", Data = 0 };
        }

        [HttpDelete("{id}")]
        public async void Delete(string slugTenant, int id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
