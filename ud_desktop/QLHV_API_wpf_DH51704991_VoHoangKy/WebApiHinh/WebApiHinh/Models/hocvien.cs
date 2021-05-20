namespace WebApiHinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hocvien")]
    public partial class hocvien
    {
        [Key]
        [StringLength(50)]
        public string mshv { get; set; }

        [StringLength(50)]
        public string tenhv { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }
    }
}
