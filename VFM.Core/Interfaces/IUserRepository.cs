using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFM.Core.Models;

namespace VFM.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task<User?> GetByEmail(string Email);

        Task<Guid> Create(User user);

        Task<Guid> Update(Guid id, string Email, string Password);

        Task<Guid> Delete(Guid id);
    }
}
