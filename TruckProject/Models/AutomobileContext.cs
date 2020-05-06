using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TruckProject.Models
{
    public partial class AutomobileContext : DbContext
    {
        public AutomobileContext()
        {
        }

        public AutomobileContext(DbContextOptions<AutomobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Truck> Truck { get; set; }
        public virtual DbSet<UserTruck> UserTruck { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TruckDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("Truck", "avto");

                entity.HasIndex(e => e.Price);

                entity.HasIndex(e => e.RegistrationPlate)
                    .HasName("IX_Unique_AvtoNumbers")
                    .IsUnique();

                entity.HasIndex(e => new { e.Model, e.Country, e.YearGraduation, e.Price, e.Brand })
                    .HasName("IX_Truck_SeekByFields");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(158)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationPlate)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTruck>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TruckId })
                    .HasName("PK__User_Tru__B1EBE2DBD8566C7E");

                entity.ToTable("User_Truck", "avto");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.UserTruck)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Truc__Truck__2A4B4B5E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTruck)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__User_Truc__UserI__29572725");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "avto");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534FFDE8C8D")
                    .IsUnique();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationToken)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
