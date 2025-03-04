using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Entities;

public partial class ApplicationDbContext : DbContext
{
  
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblEmployeeRole> TblEmployeeRoles { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblDepar__3214EC074D1202C2");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblEmplo__3214EC0751CEAA6A");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Department).WithMany(p => p.TblEmployees).HasConstraintName("FK__TblEmploy__Depar__3E52440B");
        });

        modelBuilder.Entity<TblEmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblEmplo__3214EC072343E825");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblEmployeeRoles).HasConstraintName("FK__TblEmploy__Emplo__49C3F6B7");

            entity.HasOne(d => d.Role).WithMany(p => p.TblEmployeeRoles).HasConstraintName("FK__TblEmploy__RoleI__4AB81AF0");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblRoles__3214EC0723004375");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblUsers__3214EC073E1C44E4");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
