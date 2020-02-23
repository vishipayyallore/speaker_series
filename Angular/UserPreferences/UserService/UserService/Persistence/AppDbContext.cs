using Microsoft.EntityFrameworkCore;
using UserService.Entities;

namespace UserService.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserPreference> UserPreferences { get; set; }
    }
}
