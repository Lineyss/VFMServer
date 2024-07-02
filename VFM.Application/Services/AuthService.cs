using VFM.Core.Interfaces;
using VFM.Core.Models;

namespace VFM.Application.Services
{
    public class AuthService(IHash hash, IUserRepository userRepository, IJwtService jwtService) : IAuthService
    {
        private readonly IHash hash = hash;
        private readonly IUserRepository userRepository = userRepository;
        private readonly IJwtService jwtService = jwtService;

        public async Task<bool> Register(string email, string password)
        {
            var hashedPassword = hash.Generate(password);

            try
            {
                (var user, string error) = User.Create(Guid.NewGuid(), email, hashedPassword);

                if (string.IsNullOrWhiteSpace(error))
                {
                    await userRepository.Create(user);
                    return true;
                }
            }
            catch { }

            return false;
        }
        public async Task<string> Authorization(string email, string password)
        {
            var user = await userRepository.GetByEmail(email);

            if (user == null) return string.Empty;

            var result = hash.Verify(password, user.Password);

            if (result) return jwtService.GenerateToken(user);

            return string.Empty;
        }
    }
}
