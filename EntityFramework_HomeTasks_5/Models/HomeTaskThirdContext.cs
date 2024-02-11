using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_HomeTasks_5.Models;

public partial class HomeTaskThirdContext : DbContext
{
    public HomeTaskThirdContext()
    {
    }

    public HomeTaskThirdContext(DbContextOptions<HomeTaskThirdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<KeyParam> KeyParams { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=HomeTaskThird; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_Carts_ProductId");

            entity.HasIndex(e => e.UserId, "IX_Carts_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.Carts).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.User).WithMany(p => p.Carts).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<KeyParam>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_KeyParams_ProductId");

            entity.HasIndex(e => e.WordId, "IX_KeyParams_WordId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.KeyParams).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Word).WithMany(p => p.KeyParams).HasForeignKey(d => d.WordId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Word>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
