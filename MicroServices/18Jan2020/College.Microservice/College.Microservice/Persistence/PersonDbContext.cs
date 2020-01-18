using College.Microservice.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Microservice.Persistence
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            
        }

        public DbSet<AddressData> AddressBook { get; set; }
    }
}
