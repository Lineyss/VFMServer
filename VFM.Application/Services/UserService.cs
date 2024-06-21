using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFM.Core.Interfaces;
using VFM.Core.Models;

namespace VFM.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUser() => await userRepository.Get();

        public async Task<Guid> CreateUser(User user) => await userRepository.Create(user);

        public async Task<Guid> UpdateUser(Guid id, string Email, string Password) => await userRepository.Update(id, Email, Password);
        public async Task<Guid> DeleteUser(Guid id) => await userRepository.Delete(id);
    }
}
