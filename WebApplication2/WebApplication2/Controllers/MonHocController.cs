using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MonHocController : Controller
    {
        SEP_DTBEntities1 db = new SEP_DTBEntities1();
        // GET: MonHoc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Open()
        {
            int ID = (int)Session["ID"];
            var model = db.GiangDays.Where(x => x.Status == true && x.ID_GiangVien == ID);
            return View(model);
        }

        public ActionResult Close()
        {
            int ID = (int)Session["ID"];
            var model = db.GiangDays.Where(x => x.Status == false && x.ID_GiangVien == ID);
            return View(model);
        }
    }
}