using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLHD.Controllers
{
    public class DondathangController : Controller
    {
        Models.ModelHD dc = new Models.ModelHD();
        // GET: Dondathang
        public ActionResult Index()
        {
            return View(dc.hoadons.ToList());
        }
        public ActionResult xemDonhang(string id)
        {
            Models.hoadon hd =  dc.hoadons.Find(id);
            return View(hd);
        }
        public ActionResult xoaDonhang(string id)
        {
            Models.hoadon hd = dc.hoadons.Find(id);
            hd.chitiethoadons.Clear();
            foreach(var x in dc.chitiethoadons.Where(x=>x.sohd==hd.sohd))
            {
                dc.chitiethoadons.Remove(x);
            }
            dc.hoadons.Remove(hd);
            dc.SaveChanges();
            return RedirectToAction("Index","Dondathang");
        }
    }
}