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

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAdress> UserAdresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CATSHREDIASLAPT\\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity);

            entity.ToTable("City");

            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin);

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).HasColumnName("id_login");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Login_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provider");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.IdStreet);

            entity.ToTable("Street");

            entity.Property(e => e.IdStreet).HasColumnName("id_street");
            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Streets)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Street_City");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Desciption)
                .HasColumnType("text")
                .HasColumnName("desciption");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");

            entity.HasMany(d => d.IdProducts).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "Basket",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Basket_Product1"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Basket_User"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdProduct").HasName("PK_Basket_1");
                        j.ToTable("Basket");
                        j.IndexerProperty<int>("IdUser").HasColumnName("id_user");
                        j.IndexerProperty<int>("IdProduct").HasColumnName("id_product");
                    });
        });

        modelBuilder.Entity<UserAdress>(entity =>
        {
            entity.HasKey(e => e.IdUserAdress);

            entity.Property(e => e.IdUserAdress).HasColumnName("id_user_adress");
            entity.Property(e => e.Apartment).HasColumnName("apartment");
            entity.Property(e => e.Home)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("home");
            entity.Property(e => e.IdStreet).HasColumnName("id_street");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdStreetNavigation).WithMany(p => p.UserAdresses)
                .HasForeignKey(d => d.IdStreet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAdresses_Street");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserAdresses)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAdresses_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
