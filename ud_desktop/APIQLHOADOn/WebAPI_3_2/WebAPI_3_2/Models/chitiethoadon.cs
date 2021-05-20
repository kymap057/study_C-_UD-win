namespace WebAPI_3_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitiethoadon")]
    public partial class chitiethoadon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string sohd { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string mahang { get; set; }

        public double? dongia { get; set; }

        public int? soluong { get; set; }

        public virtual hanghoa hanghoa { get; set; }

        public virtual hoadon hoadon { get; set; }
    }
}
