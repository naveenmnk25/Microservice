using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrganizationService.Models;

public partial class OrganizationServiceDbContext : DbContext
{
    public OrganizationServiceDbContext()
    {
    }

    public OrganizationServiceDbContext(DbContextOptions<OrganizationServiceDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B186298B3D4");

            entity.HasIndex(e => e.Email, "UQ__Members__A9D10534483B22EE").IsUnique();

            entity.Property(e => e.MemberId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.MemberName).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Team).WithMany(p => p.Members)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Members_Teams");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE7996624655C");

            entity.Property(e => e.TeamId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.TeamName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
