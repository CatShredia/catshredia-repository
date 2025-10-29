using JwtProject.Model;
using JwtProject.Models;
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
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderList> OrderLists { get; set; }
    
    public DbSet<Session> Sessions { get; set; }
}