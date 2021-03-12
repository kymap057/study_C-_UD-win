using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web10_3.Controllers
{
    public class MonHocController : ApiController
    {
        private Models.ModelMonHoc dc = new Models.ModelMonHoc();
        public IHttpActionResult getDSMH()//get all
        {
            var kq = dc.monhocs.Select(x => new Models.CMonHoc
            {
                msmh = x.msmh,
                tenmh=x.tenmh,
                sotiet=x.sotiet
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult getMH(string id)//get
        {
            Models.monhoc mh = dc.monhocs.Find(id);
            if (mh == null) return NotFound();
            Models.CMonHoc kq = new Models.CMonHoc
            {
                msmh = mh.msmh,
                tenmh=mh.tenmh,
                sotiet=mh.sotiet
            };
            return Ok(kq);
        }
        public IHttpActionResult deleteMonHoc(string id)
        {
            Models.monhoc mh = dc.monhocs.Find(id);
            if (mh == null) return BadRequest();
            dc.monhocs.Remove(mh);
            dc.SaveChanges();
            return Ok();
        }
        public IHttpActionResult postMonHoc(Models.monhoc mh)//create
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.monhoc mhNew = new Models.monhoc();
            Models.monhoc mhCheck = dc.monhocs.Find(mh.msmh);
            if (mhCheck != null) return BadRequest();
            mhNew.msmh = mh.msmh;
            mhNew.tenmh = mh.tenmh;
            mhNew.sotiet = mh.sotiet;
            dc.monhocs.Add(mhNew);
            dc.SaveChanges();
            return Ok();
        }
        public IHttpActionResult putMonHoc(Models.monhoc mh)//update
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.monhoc mhNew = dc.monhocs.Find(mh.msmh);
            if (mhNew == null) return BadRequest();
            mhNew.tenmh = mh.tenmh;
            mhNew.sotiet = mh.sotiet;
            dc.SaveChanges();
            return Ok();
        }
    }
}
