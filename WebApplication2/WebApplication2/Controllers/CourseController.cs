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
        sep21t22Entities1 db = new sep21t22Entities1();
        public static string makhdiemdanh = "";
        // GET: Student
        public ActionResult Index(string id)
        {
            string ma = Session["MaGV"].ToString();
            //  string ID = Session["ID"].ToString();
            var model = db.KhoaHocs.Where(x => x.MaMH == id && x.Ma==ma);
            // var bh = db.BuoiHocs.Where(x => x.MaKH == id);
            //ViewBag.Lesson = bh;
            return View(model);
        }
        // danh sach sinh vien vaf danh sach bang tham du
        public ActionResult ListStudent(string id)
        {
          //  ReturnmaKH(id);
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
        // danh sach buoi hc
        public ActionResult ListBuoi(string id)
        {
            var model = db.BuoiHocs.Where(x => x.MaKH == id);
            return View(model);
        }

        public ActionResult ListDiemDanh(string id)
        {
         
            int ID = int.Parse(id);
            var model = db.DiemDanhs.Where(x => x.ID_BuoiHoc == ID);
            var makh = db.BuoiHocs.FirstOrDefault(x => x.ID_BH == ID).MaKH;
            ViewBag.BuoiHoc = new SelectList(db.BuoiHocs.OrderByDescending(y=> y.ID_BH).Where(x => x.MaKH == makh), "ID_BH", "Buoi_thu");
           
            return View(model);
        }
        //change trang thai buoi diem danh
        public ActionResult Change(string id)
        {
            var ID = int.Parse(id);
            var ID_DD = db.DiemDanhs.FirstOrDefault(x => x.ID == ID);
            if (ID_DD.status == true)
            {
                ID_DD.status = false;
            }
            else
            {
                ID_DD.status = true;
            }
            db.SaveChanges();
            return RedirectToAction("ListDiemDanh", new { id = ID_DD.ID_BuoiHoc });
        }
        // edit change buoi diem danh
        [HttpPost]
        public ActionResult edit(string Buoithu)
        {
            return RedirectToAction("ListDiemDanh", new { id = Buoithu });
        }

        /// ----------------------------------------diem danh thu cong
        //tao buoi ngay luc chon diem danh
        public int taobuoi(string id)
        {
          
                BuoiHoc bhoc = new BuoiHoc();
                bhoc.NgayHoc = Convert.ToDateTime(DateTime.Now);
                bhoc.Buoi_thu = db.BuoiHocs.Where(x => x.MaKH == id).Count() + 1;       
                bhoc.MaKH = id;
                db.BuoiHocs.Add(bhoc);
                db.SaveChanges();
            int ii = bhoc.ID_BH;
            return ii;
        }

       
        [HttpGet]
        public ActionResult DIEMDANH(string id)
        {
           
            var list = db.ThamDus.Where(x => x.MaKH == id).ToList();
            
            return View(list);

        }

        [HttpPost]
        public ActionResult DIEMDANHS(string MaKh)
        {

            var isa = taobuoi(MaKh);
            //int ids = taobuoi(id);
            //var list = db.ThamDus.Where(x => x.MaKH == MaKh).ToList();
            //foreach (var dd in list)
            //{
            //   
            //    DiemDanh ddanh = new DiemDanh();
            //    ddanh.MSSV = dd.MSSV;
            //    ddanh.status = checked;
            //    ddanh.ID_BuoiHoc = isa;
                //    db.DiemDanhs.Add(ddanh);
                //    db.SaveChanges();
              
                //}
            
                return View();

        }
        public ActionResult ChangeCreate(string mssv, string makh, bool? status)
        {
            var idd = mssv;
            //var ID_DD = db.DiemDanhs.FirstOrDefault(x => x.ID == ID);
            //if (ID_DD.status == true)
            //{
            //    ID_DD.status = false;
            //}
            //else
            //{
            //    ID_DD.status = true;
            //}
            //db.SaveChanges();
            return RedirectToAction("ListDiemDanh", new { id = ""});
        }

        // Diem danh thu congs
        [HttpGet]
        public ActionResult DiemDanhthucong(string makh) // id truyen ma khoa hoc dang chon
        {
            int ids = taobuoi(makh);
            var list = db.ThamDus.Where(x => x.MaKH == makh).ToList();
            foreach (var dd in list)
            {
                //  var makh
                DiemDanh ddanh = new DiemDanh();
                ddanh.MSSV = dd.MSSV;
                ddanh.status = false;
                ddanh.ID_BuoiHoc = ids;
                db.DiemDanhs.Add(ddanh);
                db.SaveChanges();
                //   db.Dispose();
            }


            return View(list);
        }

    }
}