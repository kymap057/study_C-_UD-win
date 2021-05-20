namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            phieudathangs = new HashSet<phieudathang>();
        }

        [Key]
        [StringLength(50)]
        public string makh { get; set; }

        [StringLength(50)]
        public string tenkh { get; set; }

        public int? namsinh { get; set; }

        public bool? phai { get; set; }

        [StringLength(50)]
        public string dienthoai { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieudathang> phieudathangs { get; set; }
    }
}
