using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopProjectInfrastructure.DB;

public partial class ShopprojectContext : DbContext
{
    public ShopprojectContext()
    {
    }

    public ShopprojectContext(DbContextOptions<ShopprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderGame> OrderGames { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Game");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CategoryId, "ProductToProductCategory_idx");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .HasColumnName("ImageURL")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Price).HasPrecision(10, 2);

            entity.HasOne(d => d.Category).WithMany(p => p.Games)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductToProductCategory");
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("GameCategory");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Order");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "UserToOrder_idx");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserToOrder");
        });

        modelBuilder.Entity<OrderGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.GameId, "OrderGamesToGame_idx");

            entity.HasIndex(e => e.OrderId, "OrderIndex");

            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .HasColumnName("KEY")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.Game).WithMany(p => p.OrderGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderGamesToGame");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderGames)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderGamesToOrder");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "Email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Username, "UserName_UNIQUE").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Username).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
