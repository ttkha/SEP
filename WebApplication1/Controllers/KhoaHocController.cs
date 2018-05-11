using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KhoaHocController : Controller
    {
        SEPEntities1 db = new SEPEntities1();
        // GET: KhoaHoc
        // GET: KhoaHoc
        public ActionResult Index()
        {
            string magv = (string)Session["ID"];
            var list = db.GiangViens.FirstOrDefault(x => x.MaGV == magv);
            var item = db.KhoaHocs.Where(x => x.ID == list.MaKH).ToList();
            return View(item);
            
        }
        public ActionResult Detail(string id)
        {
            int makh = int.Parse(id);
            var model = db.ThamDus.Where(x => x.MaKH == makh).ToList();
            return View(model);
        }
    }
}