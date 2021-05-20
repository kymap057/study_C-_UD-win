namespace waBanhang.Models
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
            chitietphieudathangs = new HashSet<chitietphieudathang>();
            chitietphieugiaohangs = new HashSet<chitietphieugiaohang>();
        }

        [Key]
        [StringLength(50)]
        public string mahang { get; set; }

        [StringLength(50)]
        public string tenhang { get; set; }

        [StringLength(50)]
        public string donvitinh { get; set; }

        public double? dongia { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        [StringLength(50)]
        public string maloai { get; set; }

        [StringLength(50)]
        public string mansx { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietphieudathang> chitietphieudathangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietphieugiaohang> chitietphieugiaohangs { get; set; }

        public virtual loaihanghoa loaihanghoa { get; set; }

        public virtual nhasanxuat nhasanxuat { get; set; }
    }
}
