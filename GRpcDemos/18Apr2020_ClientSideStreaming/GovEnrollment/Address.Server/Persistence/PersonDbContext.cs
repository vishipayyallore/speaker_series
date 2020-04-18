using Address.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Address.Server.Persistence
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<AddressData> AddressBook { get; set; }
    }

}
