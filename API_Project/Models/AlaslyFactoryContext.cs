﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_Project.Models
{
    public partial class AlaslyFactoryContext : DbContext
    {
        public AlaslyFactoryContext()
        {
        }

        public AlaslyFactoryContext(DbContextOptions<AlaslyFactoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favourit> Favourits { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product_In_Cart> Product_In_Carts { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("Admin_PK");

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("Cart_UserID");
            });

            modelBuilder.Entity<Favourit>(entity =>
            {
                entity.HasKey(e => new { e.ProductID, e.UserID })
                    .HasName("Favourit_PK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favourits)
                    .HasForeignKey(d => d.ProductID)
                    .HasConstraintName("Favourit_ProductID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favourits)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("Favourit_UserID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CartID_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("Order_UserID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .HasConstraintName("CategoryID_FK");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SeasonID)
                    .HasConstraintName("SeasonID_FK");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeID)
                    .HasConstraintName("TypeID_FK");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductID)
                    .HasConstraintName("ProductID_FK");
            });

            modelBuilder.Entity<Product_In_Cart>(entity =>
            {
                entity.HasKey(e => new { e.ProductID, e.CartID })
                    .HasName("Product_In_Cart_PK");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Product_In_Carts)
                    .HasForeignKey(d => d.CartID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductINCart_CartID_FK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Product_In_Carts)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductINCart_Product_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}