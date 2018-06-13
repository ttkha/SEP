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
        public API api = new API();
        SepEntities db = new SepEntities();
        // GET: Student
        public ActionResult Index(string id)
        {

            //  string ID = Session["ID"].ToString();
            var model = db.KhoaHocs.Where(x => x.MaMH == id);
            return View(model);
        }

        public ActionResult ListStudent(string id)
        {
            //  int ID = int.Parse(id);
            var model = db.ThamDus.Where(x => x.MaKH == id);
            if (model.Count() == 0)
            {
                var data = api.GetMember(id);
                foreach (var item in data)
                {
                    SinhVien nStudent = new SinhVien();
                    nStudent.MSSV = item.id;
                    nStudent.Birthday = Convert.ToDateTime(item.birthday);
                    nStudent.FullName = item.fullname;
                    nStudent.LastName = item.lastname;
                    nStudent.FirstName = item.firstname;
                    db.SinhViens.Add(nStudent);

                    ThamDu nThamDu = new ThamDu();
                    nThamDu.MSSV = item.id;
                    nThamDu.MaKH = id;
                    db.ThamDus.Add(nThamDu);

                    db.SaveChanges();
                }
                model = db.ThamDus.Where(x => x.MaKH == id);
            }

            ViewBag.ID = id;
            return View(model);
        }

        public ActionResult ListBuoi(string id)
        {
            //    int ID = int.Parse(id);
            //  var  = db.BuoiHocs.Where(x => x.ID_Course == id);
            return View();
        }

        public ActionResult ListDiemDanh(string id)
        {
            int ID = int.Parse(id);
            //    var  = db.DiemDanhs.Where(x => x.ID_BuoiHoc==ID);
            return View();
        }
    }
}