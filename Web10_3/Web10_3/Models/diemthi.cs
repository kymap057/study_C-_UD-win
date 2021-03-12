namespace Web10_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("diemthi")]
    public partial class diemthi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string mshv { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string msmh { get; set; }

        [StringLength(5)]
        public string diem { get; set; }

        public virtual lylich lylich { get; set; }

        public virtual monhoc monhoc { get; set; }
    }
}
