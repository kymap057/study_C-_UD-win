namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietphieudathang")]
    public partial class chitietphieudathang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string mapdh { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string mahang { get; set; }

        public double? dongia { get; set; }

        public double? soluong { get; set; }

        public virtual hanghoa hanghoa { get; set; }

        public virtual phieudathang phieudathang { get; set; }
    }
}
