using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CreateDiemDanhController : Controller
    {
        sep21t22Entities1 db = new sep21t22Entities1();
        // GET: CreateDiemDanh
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            //All the selected are available in AvailableColours
            var list = db.ThamDus.Where(x=>x.MaKH == "MH2").ToList();
            Item item = new Item();
          //  item.AvailableColours = null;
            cThamdu c = new cThamdu();
            foreach (var x in list)
            {
                c.Id = x.MSSV;
                c.checkbox = false;
                item.AvailableColours.Add(c);
            }
            return View(item);
        }
        [HttpPost]
        public ActionResult Create(Item model)
        {
            //All the selected are available in AvailableColours

            return View(model);
        }
    }
}