namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietphieugiaohang")]
    public partial class chitietphieugiaohang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string mapgh { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string mahang { get; set; }

        [StringLength(50)]
        public string donvitinh { get; set; }

        public double? soluong { get; set; }

        public virtual hanghoa hanghoa { get; set; }

        public virtual phieugiaohang phieugiaohang { get; set; }
    }
}
