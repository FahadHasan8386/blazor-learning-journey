using argosync.Api.Entity;

namespace argosync.Api.Service
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
