using VFM.Core.Models;

namespace VFM.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}