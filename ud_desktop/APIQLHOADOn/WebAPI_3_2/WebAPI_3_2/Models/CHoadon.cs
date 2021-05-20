using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_3_2.Models
{
    public class CHoadon
    {
        public string sohd { get; set; }

        public DateTime? ngaylaphd { get; set; }

        public string tenkh { get; set; }
        public ICollection<CChitiethoadon> chitiethoadons { get; set; }
    }
}