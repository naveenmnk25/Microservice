using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Models;

public partial class OrganizationServiceDbContext : DbContext
{
    public OrganizationServiceDbContext()
    {
    }

    public OrganizationServiceDbContext(DbContextOptions<OrganizationServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppManagedBy> AppManagedBies { get; set; }

    public virtual DbSet<Application> Applications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppManagedBy>(entity =>
        {
            entity.HasKey(e => e.AppManagedById).HasName("PK__AppManag__2FCB54E671A4E54D");

            entity.ToTable("AppManagedBy");

            entity.Property(e => e.AppManagedById).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AssignedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Application).WithMany(p => p.AppManagedBies)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppManagedBy_Applications");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__C93A4C9935E88059");

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApplicationName).HasMaxLength(150);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
