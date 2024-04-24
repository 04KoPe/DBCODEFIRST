using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFIRST.Models;

public partial class ShoesWebContext : DbContext
{
    public ShoesWebContext()
    {
    }

    public ShoesWebContext(DbContextOptions<ShoesWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MDU0TB0\\SQLEXPRESS;Initial Catalog=ShoesWeb;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__AD0500864333D5E6");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("adminID");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adminName");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adminPassword");
            entity.Property(e => e.RoleId).HasColumnName("roleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Admin__roleID__398D8EEE");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__06B772B9BCE1EC84");

            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brandName");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__23CAF1F83237CC7A");

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9DF7892CF5");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(100)
                .HasColumnName("customerAddress");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customerPassword");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RoleId).HasColumnName("roleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Customers__roleI__3C69FB99");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809337D11BE4635");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.OrderAddress)
                .HasMaxLength(100)
                .HasColumnName("orderAddress");
            entity.Property(e => e.OrderDate).HasColumnName("orderDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__customer__4D94879B");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__E4FEDE2AA9D510B3");

            entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__order__5165187F");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__produ__5070F446");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__A0D9EFA67C530BA5");

            entity.Property(e => e.PaymentId).HasColumnName("paymentID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");
            entity.Property(e => e.PaymentMethodId).HasColumnName("paymentMethodID");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payments__orderI__5629CD9C");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__Payments__paymen__571DF1D5");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__46612FD8355A37FD");

            entity.Property(e => e.PaymentMethodId).HasColumnName("paymentMethodID");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(50)
                .HasColumnName("paymentMethodName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__2D10D14AE23854CB");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.ExternalUrl)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("externalURL");
            entity.Property(e => e.IsExternal).HasColumnName("isExternal");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(250)
                .HasColumnName("productDescription");
            entity.Property(e => e.ProductImage)
                .HasMaxLength(100)
                .HasColumnName("productImage");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            entity.Property(e => e.ProductQuantity).HasColumnName("productQuantity");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__brandI__440B1D61");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__catego__4316F928");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__2ECD6E24D95EE2B9");

            entity.Property(e => e.ReviewId).HasColumnName("reviewID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.ReviewContent).HasColumnName("reviewContent");
            entity.Property(e => e.ReviewDate).HasColumnName("reviewDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Reviews__custome__4AB81AF0");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Reviews__product__49C3F6B7");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__CD98460A87795F2B");

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Sizes__55B1E577926BE9B6");

            entity.Property(e => e.SizeId).HasColumnName("sizeID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.ShoeSize).HasColumnName("shoeSize");

            entity.HasOne(d => d.Product).WithMany(p => p.Sizes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Sizes__productID__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
