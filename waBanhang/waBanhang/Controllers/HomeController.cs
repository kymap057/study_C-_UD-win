using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace waBanhang.Controllers
{
    public class HomeController : Controller
    {
        private Models.ModelBanhang dc = new Models.ModelBanhang();
        // GET: Home
        public ActionResult Index()
        {
            return View(dc.hanghoas.ToList());
        }
        public ActionResult xemDSDondathang()
        {
            return View(dc.phieudathangs.ToList());
        }
        public ActionResult xemChitietDonhang(string id)
        {
            Models.phieudathang x = dc.phieudathangs.Find(id);
            if (x == null)
            {
                return RedirectToAction("index");
            }
            return View(x);
        }
        public ActionResult dongChitietDonhang()
        {
            return Content("");
        }
        public ActionResult xemGiohang()
        {
            Models.phieudathang x = Session["PhieuDatHang"] as Models.phieudathang;

            return View(x);
        }
        [HttpPost]
        public ActionResult chonMuahang(string mahang,int soluong)
        {
            Models.phieudathang x = Session["PhieuDatHang"] as Models.phieudathang;
            foreach (var a in x.chitietphieudathangs.Where(t => t.mahang == mahang))
            {

                a.soluong = soluong + a.soluong;
                return RedirectToAction("xemGiohang");
            }
            Models.hanghoa hh = dc.hanghoas.Find(mahang);
            Models.chitietphieudathang ct = new Models.chitietphieudathang();
            ct.mahang = mahang;
            ct.soluong = soluong;
            ct.hanghoa = hh;
            ct.dongia = hh.dongia;
            x.chitietphieudathangs.Add(ct);
            return RedirectToAction("xemGiohang");
        }
        public ActionResult xoaHanghoa(string id)
        {
            Models.phieudathang ct = Session["Phieudathang"] as Models.phieudathang;
            foreach (var a in ct.chitietphieudathangs.Where(x => x.mahang == id))
            {
                ct.chitietphieudathangs.Remove(a);
                break;
            }
            return View("xemGiohang", ct);
        }
    }
}