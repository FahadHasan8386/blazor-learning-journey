using argosync.Api.Models;

namespace argosync.Api.Service
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequest request);

        Task<string?> LoginAsync(LoginRequest request);
    }
}
