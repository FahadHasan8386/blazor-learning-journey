using argosync.Api.Data;
using argosync.Api.Entity;
using argosync.Api.Models;

namespace argosync.Api.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly ITokenService _tokenService;

        public AuthService(
            AppDbContext db,
            ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            if (await _db.Users.AnyAsync(x =>
                    x.Email == request.Email))
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _db.Users.Add(user);

            await _db.SaveChangesAsync();
        }

        public async Task<string?> LoginAsync(
            LoginRequest request)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x =>
                    x.Email == request.Email);

            if (user == null)
                return null;

            bool valid =
                BCrypt.Net.BCrypt.Verify(
                    request.Password,
                    user.PasswordHash);

            if (!valid)
                return null;

            return _tokenService.GenerateToken(user);
        }
    }
}
