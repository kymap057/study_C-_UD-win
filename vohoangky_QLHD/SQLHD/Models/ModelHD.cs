namespace SQLHD.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelHD : DbContext
    {
        public ModelHD()
            : base("name=ModelHD")
        {
        }

        public virtual DbSet<chitiethoadon> chitiethoadons { get; set; }
        public virtual DbSet<hanghoa> hanghoas { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<chitiethoadon>()
                .Property(e => e.sohd)
                .IsUnicode(false);

            modelBuilder.Entity<chitiethoadon>()
                .Property(e => e.mahang)
                .IsUnicode(false);

            modelBuilder.Entity<hanghoa>()
                .Property(e => e.mahang)
                .IsUnicode(false);

            modelBuilder.Entity<hanghoa>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.sohd)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.hoadon)
                .WillCascadeOnDelete(false);
        }
    }
}
