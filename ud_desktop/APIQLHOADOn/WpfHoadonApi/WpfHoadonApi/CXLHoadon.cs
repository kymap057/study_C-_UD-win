using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WpfHoadonApi
{
    class CXLHoadon
    {
        private static HttpClient hc = new HttpClient();
        public static List<CHoadon> getDSHoadon()
        {
            try
            {
                string url = @"https://localhost:44323/api/hoadon";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CHoadon>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CHoadon getHoadon(string sohd)
        {
            try
            {
                string url = @"https://localhost:44323/api/hoadon/" + sohd;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<CHoadon>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static IEnumerable<object> getDSCTHoadon(CHoadon hd)
        {
            return hd.chitiethoadons.Select(x => new
            {
                mahang= x.mahang,
                tenhang = x.hanghoa.tenhang,
                dvt = x.hanghoa.dvt,
                soluong = x.soluong,
                dongia = x.dongia,
                thanhtien = x.soluong.Value* x.dongia.Value
            }).ToList();
        }
        public static double tongThanhtienHoadon(CHoadon hd)
        {
            // vào hd ấy lấy DS CTHD ấy ra sd toán tử SUM -> tỗng theo columns: soluong vs dongia
            return hd.chitiethoadons.Sum(x => x.soluong.Value * x.dongia.Value);
        }
        public static bool themHoadon(CHoadon hv)
        {
            try
            {
                string url = @"https://localhost:44323/api/hoadon/";
                var kq = hc.PostAsJsonAsync(url, hv);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
