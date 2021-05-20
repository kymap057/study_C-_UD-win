using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WpfHoadonApi
{
    public class CHoadon
    {
        public string sohd { get; set; }

        public DateTime? ngaylaphd { get; set; }

        public string tenkh { get; set; }
        public ICollection<CChitiethoadon> chitiethoadons { get; set; }
    }
}