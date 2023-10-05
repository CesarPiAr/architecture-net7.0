using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Interfaces;
using System.Net;
using System.Security.Claims;

namespace Proyecto.API.Filters
{
    public class ValidateTenant : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var response = new ResponseApi<object>();
            response.Data = null;
            try
            {
                var user = context.HttpContext.User;
                var request = context.HttpContext.Request;
                var tenantId = request.Path.Value.Split('/')[2];

                if (user.FindFirst(ClaimTypes.SerialNumber)?.Value != tenantId)
                {
                    response.Status = HttpStatusCode.Unauthorized;
                    response.StatusText = "Unauthorized"; 
                    context.Result = new UnauthorizedObjectResult(response);
                }

                var organizationService = context.HttpContext.RequestServices.GetRequiredService<IOrganizationService>();

                if (!organizationService.AnyByTenantAsync(tenantId).GetAwaiter().GetResult())
                {
                    response.Status = HttpStatusCode.NotFound;
                    response.StatusText = "NotFound";

                    context.Result = new NotFoundObjectResult(response);
                }
            }
            catch 
            {
                response.Status = HttpStatusCode.NotFound;
                response.StatusText = "NotFound";
                context.Result = new NotFoundObjectResult(response);
            }
        }
    }
}
