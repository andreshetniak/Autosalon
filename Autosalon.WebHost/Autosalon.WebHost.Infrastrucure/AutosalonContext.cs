using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Autosalon.WebHost.Infrastrucure
{
    public partial class AutosalonContext : DbContext
    {
        public AutosalonContext()
        {
        }

        public AutosalonContext(DbContextOptions<AutosalonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Characteristics> Characteristics { get; set; }
        public virtual DbSet<DriveUnitType> DriveUnitType { get; set; }
        public virtual DbSet<FuelType> FuelType { get; set; }
        public virtual DbSet<MarkAndModel> MarkAndModel { get; set; }
        public virtual DbSet<TransmissionType> TransmissionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();

                string connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.MainImage).HasMaxLength(100);

                entity.Property(e => e.Mark)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Characteristics>(entity =>
            {
                entity.HasIndex(e => e.IdCar)
                    .HasName("AK_IdCar")
                    .IsUnique();

                entity.Property(e => e.EngineVolume).HasColumnType("decimal(3, 1)");

                entity.HasOne(d => d.DriveUnitNavigation)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.DriveUnit)
                    .HasConstraintName("FK_Characteristics_DriveUnitType");

                entity.HasOne(d => d.FuelNavigation)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.Fuel)
                    .HasConstraintName("FK_Characteristics_FuelType");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithOne(p => p.Characteristics)
                    .HasForeignKey<Characteristics>(d => d.IdCar)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Characteristics_Car");

                entity.HasOne(d => d.TransmissionNavigation)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.Transmission)
                    .HasConstraintName("FK_Characteristics_TransmissionType");
            });

            modelBuilder.Entity<DriveUnitType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MarkAndModel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Mark).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);
            });

            modelBuilder.Entity<TransmissionType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
