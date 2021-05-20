namespace WA_hinh.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelHocvien : DbContext
    {
        public ModelHocvien()
            : base("name=ModelHocvien")
        {
        }

        public virtual DbSet<hocvien> hocviens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
