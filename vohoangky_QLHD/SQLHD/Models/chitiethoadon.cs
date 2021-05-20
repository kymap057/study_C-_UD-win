namespace SQLHD.Models
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
        [Display(Name = "Mã hàng")]
        public string mahang { get; set; }
        [Display(Name = "Đơn giá")]
        public double? dongia { get; set; }
        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }

        public virtual hanghoa hanghoa { get; set; }

        public virtual hoadon hoadon { get; set; }
    }
}
