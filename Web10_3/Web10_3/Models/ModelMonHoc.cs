using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web10_3.Models
{
    public partial class ModelMonHoc : DbContext
    {
        public ModelMonHoc()
            : base("name=ModelMonHoc")
        {
        }

        public virtual DbSet<diemthi> diemthis { get; set; }
        public virtual DbSet<lop> lops { get; set; }
        public virtual DbSet<lylich> lyliches { get; set; }
        public virtual DbSet<monhoc> monhocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<diemthi>()
                .Property(e => e.mshv)
                .IsUnicode(false);

            modelBuilder.Entity<diemthi>()
                .Property(e => e.msmh)
                .IsUnicode(false);

            modelBuilder.Entity<diemthi>()
                .Property(e => e.diem)
                .IsUnicode(false);

            modelBuilder.Entity<lop>()
                .Property(e => e.malop)
                .IsUnicode(false);

            modelBuilder.Entity<lylich>()
                .Property(e => e.mshv)
                .IsUnicode(false);

            modelBuilder.Entity<lylich>()
                .Property(e => e.malop)
                .IsUnicode(false);

            modelBuilder.Entity<lylich>()
                .HasMany(e => e.diemthis)
                .WithRequired(e => e.lylich)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<monhoc>()
                .Property(e => e.msmh)
                .IsUnicode(false);

            modelBuilder.Entity<monhoc>()
                .HasMany(e => e.diemthis)
                .WithRequired(e => e.monhoc)
                .WillCascadeOnDelete(false);
        }
    }
}
