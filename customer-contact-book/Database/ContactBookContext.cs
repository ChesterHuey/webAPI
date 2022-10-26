using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class ContactBookContext : DbContext
{
    public DbSet<Group> Groups { get; set; }
  
    public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
    {
    }
}
