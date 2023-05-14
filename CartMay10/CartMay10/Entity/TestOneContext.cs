using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CartMay10.Entity
{
    public partial class TestOneContext : DbContext
    {
        public TestOneContext()
        {
        }

        public TestOneContext(DbContextOptions<TestOneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NGYNMINHVU\\SQLEXPRESS;Initial Catalog=TestOne;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IdUser).HasColumnName("idUser");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.IdCart, e.IdProduct })
                    .HasName("PK__CartItem__8BA3E8878101B79A");

                entity.ToTable("CartItem");

                entity.Property(e => e.IdCart).HasColumnName("idCart");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idProduct");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdCartNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.IdCart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Cart");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Img)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
