using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<ShopOrder> ShopOrders { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("app_user_pkey");

            entity.ToTable("app_user");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("app_user_id_role_fkey");
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.IdBasket).HasName("basket_pkey");

            entity.ToTable("basket");

            entity.Property(e => e.IdBasket).HasColumnName("id_basket");
            entity.Property(e => e.Count)
                .HasDefaultValue(0)
                .HasColumnName("count");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("basket_id_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("basket_id_user_fkey");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity).HasName("city_pkey");

            entity.ToTable("city");

            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("login_pkey");

            entity.ToTable("login");

            entity.Property(e => e.IdLogin).HasColumnName("id_login");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login1)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("login_id_user_fkey");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.IdOrderItem).HasName("order_item_pkey");

            entity.ToTable("order_item");

            entity.Property(e => e.IdOrderItem).HasColumnName("id_order_item");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("order_item_id_order_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("order_item_id_product_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(50)
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .HasColumnName("provider");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.IdRole, e.PermissionName }).HasName("role_permission_pkey");

            entity.ToTable("role_permission");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(50)
                .HasColumnName("permission_name");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("role_permission_id_role_fkey");
        });

        modelBuilder.Entity<ShopOrder>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("shop_order_pkey");

            entity.ToTable("shop_order");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IsDelivered)
                .HasDefaultValue(false)
                .HasColumnName("is_delivered");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasColumnName("is_paid");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ShopOrders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("shop_order_id_user_fkey");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.IdStreet).HasName("street_pkey");

            entity.ToTable("street");

            entity.Property(e => e.IdStreet).HasColumnName("id_street");
            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Streets)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("street_id_city_fkey");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => e.IdUserAddress).HasName("user_address_pkey");

            entity.ToTable("user_address");

            entity.Property(e => e.IdUserAddress).HasColumnName("id_user_address");
            entity.Property(e => e.Apartment).HasColumnName("apartment");
            entity.Property(e => e.Home)
                .HasMaxLength(3)
                .HasColumnName("home");
            entity.Property(e => e.IdStreet).HasColumnName("id_street");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdStreetNavigation).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.IdStreet)
                .HasConstraintName("user_address_id_street_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_address_id_user_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
