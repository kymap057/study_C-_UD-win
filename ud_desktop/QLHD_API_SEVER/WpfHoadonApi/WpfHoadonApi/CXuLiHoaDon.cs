using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WpfHoadonApi
{
    class CXuLiHoaDon
    {
        private static HttpClient hc = new HttpClient();
        public static List<CHoaDon> getDSHD()
        {
            try
            {
                string url = @"http://localhost:50962/api/hoadon";
                var res = hc.GetAsync(url);
                res.Wait();
                if (res.Result.IsSuccessStatusCode == false) return null;
                var kq = res.Result.Content.ReadAsAsync<List<CHoaDon>>();
                kq.Wait();
                return kq.Result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CHoaDon getHoaDon(string id)
        {
            try
            {
                string url = @"http://localhost:50962/api/hoadon/"+id;
                var res = hc.GetAsync(url);
                res.Wait();
                if (res.Result.IsSuccessStatusCode == false) return null;
                var kq = res.Result.Content.ReadAsAsync<CHoaDon>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CHoaDon getHoadon(string sohd)
        {
            try
            {
                string url = @"https://localhost:50962/api/hoadon/" + sohd;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<CHoaDon>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static IEnumerable<object> getDSCTHoadon(CHoaDon hd)
        {
            return hd.chiTietHoaDons.Select(x => new
            {
                mahang = x.mahang,
                tenhang = x.hanghoa.tenhang,
                dvt = x.hanghoa.dvt,
                soluong = x.soluong,
                dongia = x.dongia,
                thanhtien = x.soluong.Value * x.dongia.Value
            }).ToList();
        }
        public static double tongThanhtienHoadon(CHoaDon hd)
        {
            // vào hd ấy lấy DS CTHD ấy ra sd toán tử SUM -> tỗng theo columns: soluong vs dongia
            return hd.chiTietHoaDons.Sum(x => x.soluong.Value * x.dongia.Value);
        }
        public static bool themHoadon(CHoaDon hv)
        {
            try
            {
                string url = @"https://localhost:50962/api/hoadon/";
                var kq = hc.PostAsJsonAsync(url, hv);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
