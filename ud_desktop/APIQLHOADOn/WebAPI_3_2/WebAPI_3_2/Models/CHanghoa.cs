using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_3_2.Models
{
    public class CHanghoa
    {
        public string mahang { get; set; }

        public string tenhang { get; set; }

        public string dvt { get; set; }

        public double? dongia { get; set; }

        public ICollection<CChitiethoadon> chitiethoadons { get; set; }
    }
}