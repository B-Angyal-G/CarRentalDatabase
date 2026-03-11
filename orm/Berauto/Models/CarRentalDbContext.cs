using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Berauto.Models;

public partial class CarRentalDbContext : DbContext
{
    public CarRentalDbContext()
    {
    }

    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarStatus> CarStatuses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Fuel> Fuels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=CarRentalDb;User Id=sa;Password=RentACar_2026!;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC075C17401C");

            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC0730B390C0");

            entity.HasIndex(e => e.RegNum, "UQ__Cars__34C6A0A6F9E310BC").IsUnique();

            entity.Property(e => e.Brand).HasMaxLength(15);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Model).HasMaxLength(20);
            entity.Property(e => e.RegNum).HasMaxLength(10);

            entity.HasOne(d => d.Client).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Cars_Clients");

            entity.HasOne(d => d.Fuel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.FuelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cars_Fuel");

            entity.HasOne(d => d.Status).WithMany(p => p.Cars)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cars_CarStatus");
        });

        modelBuilder.Entity<CarStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarStatu__3214EC0712035058");

            entity.ToTable("CarStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC079E53B479");

            entity.Property(e => e.DrivingLicence).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Fuel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fuel__3214EC077C3A00F3");

            entity.ToTable("Fuel");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
