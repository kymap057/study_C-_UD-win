using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApiHinh.Models
{
    public partial class ModelHocVien : DbContext
    {
        public ModelHocVien()
            : base("name=ModelHocVien")
        {
        }

        public virtual DbSet<hocvien> hocviens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
