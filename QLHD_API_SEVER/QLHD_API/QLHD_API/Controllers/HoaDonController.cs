using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace QLHD_API.Controllers
{
    public class HoaDonController : ApiController
    {
        private Models.HoaDonModel dc = new Models.HoaDonModel();
        public IHttpActionResult getDSHoaDon()
        {
            var kq = dc.hoadons.Select(x => new CHoaDon
            {
                sohd = x.sohd,
                ngaylaphd =x.ngaylaphd,
                tenkh=x.tenkh
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult getHoaDon(string id)
        {
            Models.hoadon kq = dc.hoadons.Find(id);
            if (kq == null) return NotFound();
            CHoaDon hd = new CHoaDon {
                sohd=kq.sohd,
                ngaylaphd=kq.ngaylaphd,
                tenkh=kq.tenkh,
                chiTietHoaDons = kq.chitiethoadons.Select(x=> new CChiTietHoaDon
                {
                    dongia=x.dongia,
                    soluong=x.soluong,
                    sohd=x.sohd,
                    mahang=x.mahang,
                    hanghoa= new CHangHoa
                    {
                        mahang=x.hanghoa.mahang,
                        tenhang=x.hanghoa.tenhang,
                        dvt=x.hanghoa.dvt,
                        dongia=x.hanghoa.dongia
                    }
                }).ToList()
            }; 
            return Ok(hd);
        }
    }
}
