using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLHD.Controllers
{
    public class HomeController : Controller
    {
        Models.ModelHD dc = new Models.ModelHD();
        // GET: Home
        public ActionResult Index()
        { 
            return View(dc.hanghoas.ToList());
        }
        public ActionResult xemgiohang()
        {
            Models.hoadon hd = Session["Dondathang"] as Models.hoadon;
            return View(hd);
        }
        [HttpPost]
        public ActionResult Chonmua(string mahang,int soluong)
        {
            Models.hoadon hd = Session["Dondathang"] as Models.hoadon;
            if (ModelState.IsValid)
            {
                foreach (var x in hd.chitiethoadons.Where(x => x.mahang == mahang))
                {
                    x.soluong = x.soluong + soluong;
                    return View("xemgiohang", hd);
                    
                }
                Models.chitiethoadon cthd = new Models.chitiethoadon();
                cthd.soluong = soluong;
                cthd.mahang = mahang;
                cthd.hanghoa = dc.hanghoas.Find(mahang);
                cthd.dongia = cthd.hanghoa.dongia;
                hd.chitiethoadons.Add(cthd);
            }
            return View("xemgiohang",hd);
        }
        [HttpPost]
        public ActionResult lapDondathang(Models.hoadon x)
        {
            Models.hoadon hd = Session["Dondathang"] as Models.hoadon;
            if (ModelState.IsValid)
            {
                Models.hoadon hdCheck = dc.hoadons.Find(x.sohd);
                if(hdCheck != null)
                {
                    ModelState.AddModelError("sohd", "số hóa đơn đã tồn tại.");
                    return View("xemgiohang", hd);
                }
                if (x.ngaylaphd == null || DateTime.Now.CompareTo(x.ngaylaphd)> 0)
                {
                    ModelState.AddModelError("ngaylaphd", "chọn ngày thích hợp.");
                    return View("xemgiohang", hd);
                }
                foreach (var i in hd.chitiethoadons)
                {
                    Models.chitiethoadon cthd = new Models.chitiethoadon();
                    cthd.mahang = i.mahang;
                    cthd.sohd = x.sohd;
                    cthd.dongia = i.dongia;
                    cthd.soluong = i.soluong;
                    x.chitiethoadons.Add(cthd);
                }
                dc.hoadons.Add(x);
                dc.SaveChanges();
                hd.chitiethoadons.Clear();
            }
            return RedirectToAction("Index","Dondathang");
        }
        public ActionResult xoaHanghoa(string id)
        {
            Models.hoadon hd = Session["Dondathang"] as Models.hoadon;
            foreach(var x in hd.chitiethoadons.Where(x=>x.mahang==id))
            {
                hd.chitiethoadons.Remove(x);
                break;
            }
            return View("xemgiohang", hd);
        }
    }
}