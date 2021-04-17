using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class pocContext : DbContext
    {
        public pocContext()
        {
        }

        public pocContext(DbContextOptions<pocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAddress> TAddresses { get; set; }
        public virtual DbSet<TCategory> TCategories { get; set; }
        public virtual DbSet<TCheckout> TCheckouts { get; set; }
        public virtual DbSet<TOrder> TOrders { get; set; }
        public virtual DbSet<TProduct> TProducts { get; set; }
        public virtual DbSet<TProductImage> TProductImages { get; set; }
        public virtual DbSet<TSubCategory> TSubCategories { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=ZAID;Database=poc;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TAddress>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk");

                entity.ToTable("T_address");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Line1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Line2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__category");

                entity.ToTable("T_category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IconId).HasColumnName("IconID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ID");
            });

            modelBuilder.Entity<TCheckout>(entity =>
            {
                entity.ToTable("T_checkout");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolderName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TCheckouts)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_T_checkout_addID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TCheckouts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_T_checkout_orderID");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.ToTable("T_Orders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TOrders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_T_Orders");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.ToTable("T_products");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TProductImage>(entity =>
            {
                entity.ToTable("T_ProductImages");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Src)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductID");
            });

            modelBuilder.Entity<TSubCategory>(entity =>
            {
                entity.ToTable("T_SubCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SubCatName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TSubCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_T_SubCategory");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("T_user");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AddressId).HasColumnName("Address_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pasword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
