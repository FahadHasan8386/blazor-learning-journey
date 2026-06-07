using argosync.Api.Entity;
using argosync.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace argosync.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}
