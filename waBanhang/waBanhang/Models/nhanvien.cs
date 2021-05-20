namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhanvien")]
    public partial class nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            phieugiaohangs = new HashSet<phieugiaohang>();
        }

        [Key]
        [StringLength(50)]
        public string manv { get; set; }

        [StringLength(50)]
        public string tennv { get; set; }

        public DateTime? ngaysinh { get; set; }

        public bool? phai { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieugiaohang> phieugiaohangs { get; set; }
    }
}
