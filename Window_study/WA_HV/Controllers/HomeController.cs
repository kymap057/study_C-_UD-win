using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WA_HV.Controllers
{
    public class HomeController : Controller
    {
        private Models.ModelHocvien dc = new Models.ModelHocvien();
        // GET: Home
        public ActionResult Index()
        {
            return View(dc.lyliches.ToList());
        }
        public ActionResult xemChitiethocvien(string id)
        {
            Models.lylich hv = dc.lyliches.Find(id);
            if (hv == null)
            {
                return Redirect("/");
            }
            return View(hv);
        }
        public ActionResult formthemHV()
        {
            ViewBag.DSLop = new SelectList(dc.lops.ToList(),"malop", "tenlop");
            return View();
        }
        public ActionResult themHV(Models.lylich hv)
        {
            if (ModelState.IsValid)
            {
                Models.lylich hvCheck= dc.lyliches.Find(hv.mshv);
                if (hvCheck != null)
                {
                    ModelState.AddModelError("mshv", "Học viên đã tồn tại.");
                    ViewBag.DSLop = new SelectList(dc.lops.ToList(), "malop", "tenlop");
                    return View("formthemHV");
                }
                dc.lyliches.Add(hv);
                dc.SaveChangesAsync();
            }
            return RedirectToAction("index");
        }
    }
}