namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phieugiaohang")]
    public partial class phieugiaohang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieugiaohang()
        {
            chitietphieugiaohangs = new HashSet<chitietphieugiaohang>();
        }

        [Key]
        [StringLength(50)]
        public string mapgh { get; set; }

        public DateTime? ngaygh { get; set; }

        [StringLength(50)]
        public string diachigh { get; set; }

        [StringLength(50)]
        public string tennguoinhan { get; set; }

        [StringLength(50)]
        public string mapdh { get; set; }

        [StringLength(50)]
        public string manv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietphieugiaohang> chitietphieugiaohangs { get; set; }

        public virtual nhanvien nhanvien { get; set; }

        public virtual phieudathang phieudathang { get; set; }
    }
}
