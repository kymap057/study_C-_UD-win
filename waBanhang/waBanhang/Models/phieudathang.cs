namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phieudathang")]
    public partial class phieudathang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieudathang()
        {
            chitietphieudathangs = new HashSet<chitietphieudathang>();
            phieugiaohangs = new HashSet<phieugiaohang>();
        }

        [Key]
        [StringLength(50)]
        public string mapdh { get; set; }

        public DateTime? ngaydh { get; set; }

        public DateTime? ngaygh { get; set; }

        [StringLength(50)]
        public string diachigh { get; set; }

        [StringLength(50)]
        public string makh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietphieudathang> chitietphieudathangs { get; set; }

        public virtual khachhang khachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieugiaohang> phieugiaohangs { get; set; }
    }
}
