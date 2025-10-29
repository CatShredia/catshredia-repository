using JwtProject.Model;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.Database;

public class ContextDatabase :  DbContext
{
    public ContextDatabase(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<User> Users { get; set; }
}