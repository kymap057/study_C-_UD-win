using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfHoadonApi
{
    class CXuLiHangHoa
    {
        private static HttpClient hc = new HttpClient();
        public static List<CHangHoa> getDSHH()
        {
            try
            {
                string url = @"http://localhost:50962/api/hanghoa";
                var res = hc.GetAsync(url);
                res.Wait();
                if (res.Result.IsSuccessStatusCode == false) return null;
                var kq = res.Result.Content.ReadAsAsync<List<CHangHoa>>();
                kq.Wait();
                return kq.Result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
