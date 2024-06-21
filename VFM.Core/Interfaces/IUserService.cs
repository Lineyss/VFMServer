using VFM.Core.Models;

namespace VFM.Core.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<List<User>> GetAllUser();
        Task<Guid> UpdateUser(Guid id, string Email, string Password);
    }
}