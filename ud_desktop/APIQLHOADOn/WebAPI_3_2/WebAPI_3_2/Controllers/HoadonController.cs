using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_3_2.Controllers
{
    public class HoadonController : ApiController
    {
        private Models.ModelHoadon dc = new Models.ModelHoadon();
        public IHttpActionResult getDSHoadon()
        {
            var kq = dc.hoadons.Select(x => new Models.CHoadon
            {
                sohd = x.sohd,
                ngaylaphd = x.ngaylaphd,
                tenkh = x.tenkh
                // ko cần đưa info detail HoaDon
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult getHoadon(string id)
        {
            // Trả về hđ full
            Models.hoadon hdTemp = dc.hoadons.Find(id); // lấy từ DB -> kdl Class auto
            if (hdTemp == null) return NotFound();
            Models.CHoadon hd = new Models.CHoadon // hiện về Client -> kdl Class handmade 
            {
                sohd = hdTemp.sohd,
                ngaylaphd = hdTemp.ngaylaphd,
                tenkh = hdTemp.tenkh,
                chitiethoadons = new List<Models.CChitiethoadon>() // thuộc tính DS -> ko ép ngay
            };
            // ép riêng mỗi lần lặp cho CTHD
            foreach(Models.chitiethoadon t in hdTemp.chitiethoadons)
            {
                Models.CChitiethoadon ct = new Models.CChitiethoadon
                {
                    sohd = t.sohd,
                    mahang = t.mahang,
                    soluong = t.soluong,
                    dongia = t.dongia,
                    hanghoa = new Models.CHanghoa // Thuộc tính đơn -> ép ngay
                    {
                        mahang = t.hanghoa.mahang,
                        tenhang = t.hanghoa.tenhang,
                        dvt = t.hanghoa.dvt,
                        dongia = t.hanghoa.dongia
                    }
                };
                hd.chitiethoadons.Add(ct);
            }
            return Ok(hd);
        }
        public IHttpActionResult postHoadon(Models.CHoadon hd)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.hoadon a = new Models.hoadon
            {
                sohd = hd.sohd,
                ngaylaphd = hd.ngaylaphd,
                tenkh = hd.tenkh,
                chitiethoadons = hd.chitiethoadons.Select(x => new Models.chitiethoadon
                {
                    sohd= x.sohd,
                    mahang=x.mahang,
                    dongia=x.dongia,
                    soluong=x.soluong
                }).ToList()
            };
            dc.hoadons.Add(a);
            dc.SaveChanges();
            return Ok();
        }
    }
}
