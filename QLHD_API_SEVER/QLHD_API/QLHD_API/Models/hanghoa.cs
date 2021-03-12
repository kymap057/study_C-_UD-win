namespace QLHD_API.Models
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
        public string mahang { get; set; }

        [StringLength(50)]
        public string tenhang { get; set; }

        [StringLength(50)]
        public string dvt { get; set; }

        public double? dongia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }
    }
}
