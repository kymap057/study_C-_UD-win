using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfHinh
{
    class CXuLyHocVien
    {
        private static HttpClient hc = new HttpClient();


        public static List<CHocvien> getDSHocvien()
        {
            try
            {
                string url = @"https://localhost:44536/api/hocvien";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CHocvien>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }  
        }
        public static byte[] getHinhHocvien(string tenfile)
        {
            try
            {
                string url = @"https://localhost:44536/api/bytearray?fileName="+tenfile;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<byte[]>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static bool themHocvien(CHocvien hv)
        {
            try
            {
                string url = @"https://localhost:44536/api/hocvien";
                var kq = hc.PostAsJsonAsync(url,hv);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool themHinhHocvien(string tenfile, byte[] bufHinh)
        {
            try
            {
                string url = @"https://localhost:44536/api/bytearray?fileName=" + tenfile;
                HttpContent content = new ByteArrayContent(bufHinh);
                var kq = hc.PostAsync(url, content);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool xoaHocvien(string mahv)
        {
            try
            {
                string url = @"https://localhost:44536/api/hocvien/"+mahv;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool xoaHinhHocvien(string tenfile)
        {
            try
            {
                string url = @"https://localhost:44536/api/bytearray?fileName=" + tenfile;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool suaHocvien(CHocvien hv)
        {
            try
            {
                string url = @"https://localhost:44536/api/hocvien";
                var kq = hc.PutAsJsonAsync(url, hv);
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
