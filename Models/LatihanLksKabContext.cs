using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models;

public partial class LatihanLksKabContext : DbContext
{
    public LatihanLksKabContext()
    {
    }

    public LatihanLksKabContext(DbContextOptions<LatihanLksKabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Detailorder> Detailorders { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Headorder> Headorders { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-70HB7RB;Initial Catalog=Latihan_LKS_Kab;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Bank1);

            entity.ToTable("bank");

            entity.Property(e => e.Bank1)
                .HasMaxLength(50)
                .HasColumnName("bank");
        });

        modelBuilder.Entity<Date>(entity =>
        {
            entity.ToTable("date");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date1)
                .HasColumnType("date")
                .HasColumnName("date");
        });

        modelBuilder.Entity<Detailorder>(entity =>
        {
            entity.HasKey(e => e.Detailid);

            entity.ToTable("detailorder");

            entity.Property(e => e.Detailid).HasColumnName("detailid");
            entity.Property(e => e.Menuid).HasColumnName("menuid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Menu).WithMany(p => p.Detailorders)
                .HasForeignKey(d => d.Menuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detailorder_menu");

            entity.HasOne(d => d.Order).WithMany(p => p.Detailorders)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detailorder_headorder");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employee");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Handphone)
                .HasMaxLength(13)
                .HasColumnName("handphone");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
        });

        modelBuilder.Entity<Headorder>(entity =>
        {
            entity.HasKey(e => e.Orderid);

            entity.ToTable("headorder");

            entity.Property(e => e.Orderid)
                .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.Bank)
                .HasMaxLength(50)
                .HasColumnName("bank");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Memberid).HasColumnName("memberid");
            entity.Property(e => e.Payment)
                .HasMaxLength(50)
                .HasColumnName("payment");

            entity.HasOne(d => d.Employee).WithMany(p => p.Headorders)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_headorder_headorder");

            entity.HasOne(d => d.Member).WithMany(p => p.Headorders)
                .HasForeignKey(d => d.Memberid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_headorder_member");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("income");

            entity.Property(e => e.Income1).HasColumnName("income");
            entity.Property(e => e.Month)
                .HasMaxLength(50)
                .HasColumnName("month");
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .HasColumnName("year");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("member");

            entity.Property(e => e.Memberid).HasColumnName("memberid");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Handphone)
                .HasMaxLength(50)
                .HasColumnName("handphone");
            entity.Property(e => e.Joindate)
                .HasColumnType("date")
                .HasColumnName("joindate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("menu");

            entity.Property(e => e.Menuid).HasColumnName("menuid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Status1);

            entity.ToTable("status");

            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
