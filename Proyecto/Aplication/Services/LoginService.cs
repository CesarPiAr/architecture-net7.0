using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Interfaces;

namespace Proyecto.API.Aplication.Services
{
    public class LoginService: ILoginService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public LoginService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<AuthToken> ExecuteAsync(LoginInput request) 
        {
            var user = await _userService.GetByEmailAndPasswordAsync(request.Email, request.Password);
            
            if (user != null) 
            {
                return _jwtService.GenerateJwt(user);
            }
            return null;
        }
    }
}
