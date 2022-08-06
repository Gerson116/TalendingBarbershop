using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TalendingBarbershop.Data.Models
{
    public partial class DbTalendigBarbershopContext : DbContext
    {
        public DbTalendigBarbershopContext()
        {
        }

        public DbTalendigBarbershopContext(DbContextOptions<DbTalendigBarbershopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOrderDetails> TblOrderDetails { get; set; }
        public virtual DbSet<TblOrders> TblOrders { get; set; }
        public virtual DbSet<TblPaidTypes> TblPaidTypes { get; set; }
        public virtual DbSet<TblQuotes> TblQuotes { get; set; }
        public virtual DbSet<TblRoles> TblRoles { get; set; }
        public virtual DbSet<TblServices> TblServices { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = DbTalendigBarbershop; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOrderDetails>(entity =>
            {
                entity.ToTable("tblOrderDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_id_tblOrderDetails");
            });

            modelBuilder.Entity<TblOrders>(entity =>
            {
                entity.ToTable("tblOrders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.IsPaid).HasColumnName("is_paid");

                entity.Property(e => e.PaidTypeId).HasColumnName("paid_type_id");

                entity.HasOne(d => d.PaidType)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.PaidTypeId)
                    .HasConstraintName("FK_paid_type_id_tblPaidTypes");
            });

            modelBuilder.Entity<TblPaidTypes>(entity =>
            {
                entity.ToTable("tblPaidTypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblQuotes>(entity =>
            {
                entity.ToTable("tblQuotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblQuotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_id_tblQuotes");
            });

            modelBuilder.Entity<TblRoles>(entity =>
            {
                entity.ToTable("tblRoles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblServices>(entity =>
            {
                entity.ToTable("tblServices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("date");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_role_id_tblRoles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
