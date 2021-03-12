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
    }
}
