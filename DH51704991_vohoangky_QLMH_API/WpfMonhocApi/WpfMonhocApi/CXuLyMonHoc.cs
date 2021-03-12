using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WpfMonhocApi
{
    class CXuLyMonHoc
    {
        private static HttpClient hc = new HttpClient();

        public static List<CMonHoc> getDSMH()
        {
            try
            {
                string url = @"https://localhost:44381/api/monhoc";
                var res = hc.GetAsync(url);
                res.Wait();
                if (res.Result.IsSuccessStatusCode == false) { return null; }
                HttpContent x = res.Result.Content;
                var z = x.ReadAsAsync<List<CMonHoc>>();
                z.Wait();
                return z.Result;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public static CMonHoc getMH(string id)
        {
            try
            {
                string url = @"https://localhost:44381/api/monhoc/"+id;
                var res = hc.GetAsync(url);
                res.Wait();
                if (res.Result.IsSuccessStatusCode == false) { return null; }
                HttpContent x = res.Result.Content;
                var z = x.ReadAsAsync<CMonHoc>();
                z.Wait();
                return z.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool addMonHoc(CMonHoc mh)
        {
            try
            {
                string url = @"https://localhost:44381/api/monhoc/";
                var res = hc.PostAsJsonAsync<CMonHoc>(url,mh);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool deleteMonHoc(string id)
        {
            try
            {
                string url = @"https://localhost:44381/api/monhoc/"+id;
                var res = hc.DeleteAsync(url);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool updateMonHoc(CMonHoc mh)
        {
            try
            {
                string url = @"https://localhost:44381/api/monhoc/";
                var res = hc.PutAsJsonAsync<CMonHoc>(url, mh);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
