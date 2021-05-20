using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLHD_API.Controllers
{
    public class HangHoaController : ApiController
    {
        private Models.HoaDonModel dc = new Models.HoaDonModel();
        public IHttpActionResult getDSHH()
        {
            var kq = dc.hanghoas.Select(x => new CHangHoa
            {
                mahang=x.mahang,
                tenhang=x.tenhang,
                dvt=x.dvt,
                dongia=x.dongia
            });
            return Ok(kq.ToList());
        }
    }
}
