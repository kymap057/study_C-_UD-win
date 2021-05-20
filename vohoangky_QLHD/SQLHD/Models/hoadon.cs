namespace SQLHD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadon()
        {
            chitiethoadons = new HashSet<chitiethoadon>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Số hóa đơn")]
        public string sohd { get; set; }
        [Display(Name = "Ngày lập")]
        public DateTime? ngaylaphd { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khác hàng")]
        public string tenkh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }
    }
}
