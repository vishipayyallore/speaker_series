using College.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Service.Persistence
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            
        }

        public DbSet<AddressData> AddressBook { get; set; }

        public DbSet<HealthData> Health { get; set; }
    }
}
