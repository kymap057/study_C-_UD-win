using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiHinh.Controllers
{
    public class HocvienController : ApiController
    {
        private Models.ModelHocVien dc = new Models.ModelHocVien();
        public IHttpActionResult getDSHocvien()
        {
            var kq = dc.hocviens.Select(x => new Models.CHocvien
            {
                mshv=x.mshv,
                tenhv=x.tenhv,
                hinh=x.hinh
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult postHocvien(Models.CHocvien hv)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.hocvien a = new Models.hocvien
            {
                mshv=hv.mshv,
                tenhv= hv.tenhv,
                hinh=hv.hinh
            };
            dc.hocviens.Add(a);
            dc.SaveChanges();
            return Ok();
        }
        public IHttpActionResult deleteHocvien(string id)
        {
            Models.hocvien hv = dc.hocviens.Find(id);
            if (hv == null) return NotFound();
            dc.hocviens.Remove(hv);
            dc.SaveChanges();
            return Ok();
        }
        public IHttpActionResult putHocvien(Models.CHocvien hv)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.hocvien a = dc.hocviens.Find(hv.mshv);
            if (a == null) return NotFound();
            a.tenhv = hv.tenhv;
            a.hinh = hv.hinh;
            dc.SaveChanges();
            return Ok();
        }
    }
}
