
namespace VFM.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authorization(string email, string password);
        Task<bool> Register(string email, string password);
    }
}