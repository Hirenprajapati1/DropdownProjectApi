using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DropdownProject.Models.Entity
{
    public partial class database2Context : DbContext
    {
        public database2Context()
        {
        }

        public database2Context(DbContextOptions<database2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=database2;Integrated Security=True;Connect Timeout=30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tblDepar__B2079BCD1401A827");

                entity.ToTable("tblDepartment");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.ToTable("tblEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__tblEmploy__Depar__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
