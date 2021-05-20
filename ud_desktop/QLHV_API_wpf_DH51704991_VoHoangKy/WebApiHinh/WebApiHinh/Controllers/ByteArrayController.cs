using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace WebApiHinh.Controllers
{
    public class ByteArrayController : ApiController
    {
        private string getDuongdan()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"HinhAnh\";
        }
        public IHttpActionResult getByteArray(string fileName)
        {
            try
            {
                string tenfile = getDuongdan() + fileName;
                if (File.Exists(tenfile) == false) return NotFound();
                FileStream f = new FileStream(tenfile, FileMode.Open, FileAccess.Read);
                byte[] buf = new byte[f.Length];
                f.Read(buf, 0, (int)f.Length);
                f.Close();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        public IHttpActionResult postByteArray(string fileName)
        {
            try
            {
                var kq = Request.Content.ReadAsByteArrayAsync();
                kq.Wait();
                if (kq.IsCompleted == false) return BadRequest();
                string tenfile = getDuongdan() + fileName;
                FileStream f = new FileStream(tenfile, FileMode.Create, FileAccess.Write);
                f.Write(kq.Result, 0, kq.Result.Length);
                f.Close();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult deleteByteArray(string fileName)
        {
            try
            {
                string tenfile = getDuongdan() + fileName;
                if (File.Exists(tenfile) == false) return NotFound();
                File.Delete(tenfile);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
