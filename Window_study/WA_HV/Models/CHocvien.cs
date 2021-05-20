using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WA_HV.Models
{
    public class CHocvien
    {
        [Display(Name ="Mã số")]
        [Required(ErrorMessage ="Nhập mã số học viên!")]
        public string mshv { get; set; }
        [Display(Name = "Tên Học Viên")]
        [Required(ErrorMessage = "Nhập tên học viên!")]
        public string tenhv { get; set; }
        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage ="Nhập ngày sinh học viên!")]
        public DateTime? ngaysinh { get; set; }
        [Display(Name = "Giới tính")]
        public bool? phai { get; set; }
        [Display(Name = "Mã lớp")]
        [Required(ErrorMessage ="Nhập mã lớp!")]
        public string malop { get; set; }
    }
}