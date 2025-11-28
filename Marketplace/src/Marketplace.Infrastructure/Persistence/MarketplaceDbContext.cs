using Marketplace.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Persistence;

public class MarketplaceDbContext : DbContext
{
    public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Country
        builder.Entity<Country>(entity => { entity.Property(e => e.Name).IsRequired().HasMaxLength(50); });

        // City
        builder.Entity<City>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Street
        builder.Entity<Street>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.HasOne(s => s.City)
                .WithMany(c => c.Streets)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Address
        builder.Entity<Address>(entity =>
        {
            entity.Property(e => e.HouseNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Corpus).HasMaxLength(50); // nullable in SQL → optional
            entity.Property(e => e.Apartment).HasMaxLength(50); // nullable in SQL → optional

            entity.HasIndex(a => new { a.StreetId, a.HouseNumber, a.Corpus, a.Apartment }).IsUnique();

            entity.HasOne(a => a.Street)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.StreetId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Warehouse
        builder.Entity<Warehouse>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.HasOne(w => w.Address)
                .WithMany(a => a.Warehouses)
                .HasForeignKey(w => w.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // User
        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Login).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.EditedAt).IsRequired();
        });

        // Seller (one-to-one with User)
        builder.Entity<Seller>(entity =>
        {
            entity.HasOne(s => s.User)
                .WithOne(u => u.Seller)
                .HasForeignKey<Seller>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Category
        builder.Entity<Category>(entity => { entity.Property(e => e.Name).IsRequired().HasMaxLength(50); });

        // Tag
        builder.Entity<Tag>(entity => { entity.Property(e => e.Name).IsRequired().HasMaxLength(50); });

        // Product
        builder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Sku).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.EditedAt).IsRequired();

            entity.HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ProductTag (join entity)
        builder.Entity<ProductTag>(entity =>
        {
            entity.HasKey(pt => new { pt.ProductId, pt.TagId });

            entity.HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Inventory
        builder.Entity<Inventory>(entity =>
        {
            // Explicitly map properties to lowercase column names
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Reserved).HasColumnName("reserved");

            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.Reserved).IsRequired();

            // Now use unquoted or consistently quoted names in constraints
            entity.HasCheckConstraint("CK_Inventory_Quantity", "quantity >= 0");
            entity.HasCheckConstraint("CK_Inventory_Reserved", "reserved >= 0 AND reserved <= quantity");

            entity.HasIndex(i => new { i.ProductId, i.WarehouseId }).IsUnique();

            entity.HasOne(i => i.Product)
                .WithMany(p => p.InventoryItems)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(i => i.Warehouse)
                .WithMany(w => w.InventoryItems)
                .HasForeignKey(i => i.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // InventoryTransaction
        builder.Entity<InventoryTransaction>(entity =>
        {
            entity.Property(e => e.TxnType).IsRequired();
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();

            entity.HasOne(t => t.Inventory)
                .WithMany(i => i.Transactions)
                .HasForeignKey(t => t.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // PostgreSQL enum
        builder.HasPostgresEnum<TxnType>();

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                property.SetColumnName(property.Name.ToLowerInvariant());
            }
        }
    }
}