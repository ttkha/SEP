using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CourseController : Controller
    {
        SEP_DTBEntities1 db = new SEP_DTBEntities1();
        // GET: Student
        public ActionResult Index(string id)
        {
            int maMH = int.Parse(id);
            var model = db.Courses.Where(x => x.MaMH == maMH);
            return View(model);
        }

        public ActionResult ListStudent(string id)
        {
            int ID = int.Parse(id);
            var model = db.ThamDus.Where(x => x.ID_Course == ID);
            ViewBag.ID = ID;
            return View(model);
        }

        public ActionResult ListBuoi(string id)
        {
            int ID = int.Parse(id);
            var model = db.BuoiHocs.Where(x => x.ID_Course == ID);
            return View(model);
        }

        public ActionResult ListDiemDanh(string id)
        {
            int ID = int.Parse(id);
            var model = db.DiemDanhs.Where(x => x.ID_BuoiHoc==ID);
            return View(model);
        }
    }
}