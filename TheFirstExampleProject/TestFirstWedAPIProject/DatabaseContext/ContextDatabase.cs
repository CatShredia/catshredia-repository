using Microsoft.EntityFrameworkCore;
using TestFirstWedAPIProject.models;

namespace TestFirstWedAPIProject.DatabaseContext;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions options) : base(options)
    {
    }

    // Model - Tables
    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
}