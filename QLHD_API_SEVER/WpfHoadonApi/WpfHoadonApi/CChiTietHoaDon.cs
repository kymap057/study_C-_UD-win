using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WpfHoadonApi
{
    public class CChiTietHoaDon
    {
        public string mahang { get; set; }

        public double? dongia { get; set; }

        public int? soluong { get; set; }

        public CHangHoa hanghoa { get; set; }

        public  CHoaDon hoaDon{ get; set; }
    }
}