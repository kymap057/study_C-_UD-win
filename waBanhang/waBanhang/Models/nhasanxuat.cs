namespace waBanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhasanxuat")]
    public partial class nhasanxuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhasanxuat()
        {
            hanghoas = new HashSet<hanghoa>();
        }

        [Key]
        [StringLength(50)]
        public string mansx { get; set; }

        [StringLength(50)]
        public string tennsx { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hanghoa> hanghoas { get; set; }
    }
}
