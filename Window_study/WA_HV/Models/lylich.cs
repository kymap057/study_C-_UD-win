namespace WA_HV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lylich")]
    [MetadataType(typeof(CHocvien))]
    public partial class lylich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lylich()
        {
            diemthis = new HashSet<diemthi>();
        }

        [Key]
        [StringLength(10)]
        public string mshv { get; set; }

        [StringLength(50)]
        public string tenhv { get; set; }

        public DateTime? ngaysinh { get; set; }

        public bool? phai { get; set; }

        [StringLength(10)]
        public string malop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemthi> diemthis { get; set; }

        public virtual lop lop { get; set; }
    }
}
