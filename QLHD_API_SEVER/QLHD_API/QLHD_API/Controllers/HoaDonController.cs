using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
