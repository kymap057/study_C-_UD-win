namespace SQLHD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hanghoa")]
    public partial class hanghoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hanghoa()
        {
            chitiethoadons = new HashSet<chitiethoadon>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã hàng")]
        public string mahang { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên hàng")]
        public string tenhang { get; set; }

        [StringLength(50)]
        [Display(Name = "Đơn vị tính")]
        public string dvt { get; set; }
        [Display(Name = "đơn giá")]
        public double? dongia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }
    }
}
