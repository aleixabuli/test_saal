using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infra.FoodDelivery.Persistence.Model;

public partial class FoodDeliveryContext : DbContext, IFoodDeliveryContext
{
    public FoodDeliveryContext()
    {
    }

    public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsOrder> ProductsOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=testsaaldb.c7uyqk6eonsb.eu-central-1.rds.amazonaws.com;port=3306;database=FoodDelivery;user=root;password=rootroot");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeliveryOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DeliveryOrder");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ClientName).HasMaxLength(255);
            entity.Property(e => e.ClientSurname).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(150);
            entity.Property(e => e.Direction).HasMaxLength(500);
            entity.Property(e => e.TotalToPay).HasPrecision(10);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.UrlImage).HasMaxLength(2000);
        });

        modelBuilder.Entity<ProductsOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.DeliveryOrderId, "FK_ProductsOrders_DeliveryOrder");

            entity.HasIndex(e => e.ProductId, "FK_ProductsOrders_Product");

            entity.HasOne(d => d.DeliveryOrder).WithMany(p => p.ProductsOrders)
                .HasForeignKey(d => d.DeliveryOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsOrders_DeliveryOrder");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsOrders_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
