using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WA_hinh.Controllers
{
    public class HomeController : Controller
    {
        Models.ModelHocvien dc = new Models.ModelHocvien();
        // GET: Home
        public ActionResult Index()
        {
            return View(dc.hocviens.ToList());
        }
        public ActionResult xemChiTietHocVien(string id)
        {
            Models.hocvien hv = dc.hocviens.Find(id);
            return View(hv);
        }

        public ActionResult formThemHocVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themHocVien(Models.hocvien hv, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Models.hocvien x = dc.hocviens.Find(hv.mshv);
                if (x != null)
                {
                    ModelState.AddModelError("mshv", "Trùng khóa chính !!!");
                    return View("formThemHocVien");
                }
                if (file == null)
                {
                    hv.hinh = "";
                }
                else
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    hv.hinh = hv.mshv + fi.Extension;
                    string tenfile = AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + hv.hinh;
                    file.SaveAs(tenfile);
                }
                dc.hocviens.Add(hv);
                dc.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult formXoaHocVien(string id)
        {
            Models.hocvien hv = dc.hocviens.Find(id);
            return View(hv);
        }
        public ActionResult xoaHocVien(string id)
        {
            Models.hocvien hv = dc.hocviens.Find(id);
            if (hv.hinh != "")
            {
                string tenfile = AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + hv.hinh;
                if (System.IO.File.Exists(tenfile))
                    System.IO.File.Delete(tenfile);
            }
            dc.hocviens.Remove(hv);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult formSuaHocVien(string id)
        {
            Models.hocvien hv = dc.hocviens.Find(id);
            return View(hv);
        }

        //[HttpPost]
        //public ActionResult SuaHocVien(Models.hocvien hv, HttpPostedFileBase file, bool? coSua)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Models.hocvien x = dc.hocviens.Find(hv.mshv);
        //        x.tenhv = hv.tenhv;
        //        if (coSua != null && coSua == true)
        //        {

        //        }
        //        return View();
        //    }
        //}
    }
}