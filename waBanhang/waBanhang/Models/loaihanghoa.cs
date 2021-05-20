namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaihanghoa")]
    public partial class loaihanghoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loaihanghoa()
        {
            hanghoas = new HashSet<hanghoa>();
        }

        [Key]
        [StringLength(50)]
        public string maloai { get; set; }

        [StringLength(50)]
        public string tenloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hanghoa> hanghoas { get; set; }
    }
}
