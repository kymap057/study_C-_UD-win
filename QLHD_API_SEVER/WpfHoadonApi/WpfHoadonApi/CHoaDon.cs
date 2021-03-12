using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WpfHoadonApi
{
    public class CHoaDon
    {
        public string sohd { get; set; }
        public DateTime? ngaylaphd { get; set; }
        public string tenkh { get; set; }
        public ICollection<CChiTietHoaDon> chiTietHoaDons { get; set; }
    }
}