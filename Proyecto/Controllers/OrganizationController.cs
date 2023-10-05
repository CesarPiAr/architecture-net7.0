using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Interfaces;
using System.Net;

namespace Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<ResponseApi<List<OrganizationOutput>>> Get()
        {
            var result = new ResponseApi<List<OrganizationOutput>>();
            result.Status = HttpStatusCode.OK;
            try
            {
                result.Data = await _organizationService.GetAllAsync();
            }
            catch (Exception ex)
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ResponseApi<OrganizationOutput>> Get(int id)
        {
            var result = new ResponseApi<OrganizationOutput>();
            result.Status = HttpStatusCode.OK;
            try
            {
                result.Data = await _organizationService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }

            return result;
        }

        [HttpPost]
        public async Task<ResponseApi<bool>> Post([FromBody] OrganizationInput organization)
        {
            var result = new ResponseApi<bool>();
            result.Status = HttpStatusCode.OK;
            result.Data = false;
            try
            {
                await _organizationService.CreateAsync(organization);
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
        public async Task<ResponseApi<int>> Put(int id, [FromBody] OrganizationInput organization)
        {
            if (id == organization.Id)
            {
                await _organizationService.UpdateAsync(organization);
                return new ResponseApi<int> { Status = HttpStatusCode.OK, Data = id };
            }
            return new ResponseApi<int> { Status = HttpStatusCode.Conflict, StatusText = "Id is not valid", Data = 0 };
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _organizationService.DeleteAsync(id);
        }
    }
}
