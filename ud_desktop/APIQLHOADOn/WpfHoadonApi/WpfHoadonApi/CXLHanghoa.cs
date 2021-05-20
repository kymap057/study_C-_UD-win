using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // cho Client nc vs Server trên trời

namespace WpfHoadonApi
{
    class CXLHanghoa
    {
        private static HttpClient hc = new HttpClient();
        public static List<CHanghoa> getDSHanghoa()
        {
            try
            {
                string url = @"https://localhost:44323/api/hanghoa";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CHanghoa>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
