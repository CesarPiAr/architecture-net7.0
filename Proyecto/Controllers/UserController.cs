using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Interfaces;
using System.Net;

namespace Proyecto.API.Controllers
{
    [Route("api/Users/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public UserController(ILoginService loginService, IUserService userService) 
        {
            _loginService = loginService;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Access([FromBody] LoginInput login)
        {
            ResponseApi<AuthToken> response = new ResponseApi<AuthToken>();
            response.Data = await _loginService.ExecuteAsync(login);
            if (response.Data != null)
            {
                response.Status = HttpStatusCode.OK;
                response.StatusText = "POST Request successful.";
            }
            else 
            {
                response.Status = HttpStatusCode.Unauthorized;
                response.StatusText = "Email or Password is invalid";
            }

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<ResponseApi<List<UserOutput>>> Get()
        {
            var result = new ResponseApi<List<UserOutput>>();
            result.Status = HttpStatusCode.OK;
            try
            {
                result.Data = await _userService.GetAllAsync();
            }
            catch (Exception ex)
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }

            return result;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ResponseApi<UserOutput>> Get(int id)
        {
            var result = new ResponseApi<UserOutput>();
            result.Status = HttpStatusCode.OK;
            try
            {
                result.Data = await _userService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                result.Status = HttpStatusCode.Conflict;
                result.StatusText = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<ResponseApi<bool>> Post([FromBody] UserInput user)
        {
            var result = new ResponseApi<bool>();
            result.Status = HttpStatusCode.OK;
            result.Data = false;
            try
            {
                await _userService.CreateAsync(user);
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
        [Authorize]
        public async Task<ResponseApi<int>> Put(int id, [FromBody] UserInput user)
        {
            if (id == user.Id)
            {
                await _userService.UpdateAsync(user);
                return new ResponseApi<int> { Status = HttpStatusCode.OK, Data = id };
            }
            return new ResponseApi<int> { Status = HttpStatusCode.Conflict, StatusText = "Id is not valid", Data = 0 };
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async void Delete(int id)
        {
            await _userService.DeleteAsync(id);
        }

    }
}
