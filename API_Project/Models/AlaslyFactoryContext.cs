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

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favourit> Favourits { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductInCart> ProductInCarts { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=AlaslyFactory;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Favourit>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.UserId })
                    .HasName("Favourit_PK");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favourits)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Favourit_ProductID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("CartID_FK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("CategoryID_FK");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SeasonId)
                    .HasConstraintName("SeasonID_FK");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("TypeID_FK");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductID_FK");
            });

            modelBuilder.Entity<ProductInCart>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CartId })
                    .HasName("Product_In_Cart_PK");

                entity.ToTable("Product_In_Cart");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.ProductInCarts)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("ProductINCart_CartID_FK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInCarts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductINCart_Product_FK");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("Season");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
