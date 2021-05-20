using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_3_2.Models
{
    public class CChitiethoadon
    {
        public string sohd { get; set; }

        public string mahang { get; set; }

        public double? dongia { get; set; }

        public int? soluong { get; set; }

        public CHanghoa hanghoa { get; set; }

        public CHoadon hoadon { get; set; }
    }
}