using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;

namespace Proyecto.API.Aplication.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserOutput>> GetAllAsync()
        {
            var list = await _userRepository.GetAllAsync();
            return list.Select(m => new UserOutput { Id = m.Id, Email = m.Email, Password = m.Password, OrganizationId = m.OrganizacionId }).ToList();
        }

        public async Task<List<UserOutput>> GetAllByOrganizationIdAsync(int id)
        {
            var list = await _userRepository.GetAllByOrganizationIdAsync(id);
            return list.Select(m => new UserOutput { Id = m.Id, Email = m.Email, Password = m.Password, OrganizationId = m.OrganizacionId }).ToList();
        }

        public async Task<Usuario> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _userRepository.GetByEmailAndPasswordAsync(email, password);
        }

        public async Task<UserOutput> GetByIdAsync(int id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            return new UserOutput { Id = result.Id, Email = result.Email, Password = result.Password, OrganizationId = result.OrganizacionId };
        }

        public async Task CreateAsync(UserInput user)
        {
            await _userRepository.CreateAsync(new Usuario { Email = user.Email, Password = user.Password, OrganizacionId = user.OrganizationId });
        }

        public async Task UpdateAsync(UserInput user)
        {
            if (user.Id <= 0) 
            {
                throw new Exception("Id is not valid");
            }
            await _userRepository.UpdateAsync(new Usuario { Id = user.Id, Email = user.Email, Password = user.Password, OrganizacionId = user.OrganizationId });
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            await _userRepository.DeleteAsync(id);
        }

    }
}
