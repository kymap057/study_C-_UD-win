namespace Web10_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("monhoc")]
    public partial class monhoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public monhoc()
        {
            diemthis = new HashSet<diemthi>();
        }

        [Key]
        [StringLength(10)]
        public string msmh { get; set; }

        [StringLength(50)]
        public string tenmh { get; set; }

        public int? sotiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemthi> diemthis { get; set; }
    }
}
