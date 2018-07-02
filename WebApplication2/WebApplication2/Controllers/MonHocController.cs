﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MonHocController : Controller
    {
        sep21t22Entities db = new sep21t22Entities();
        // GET: MonHoc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Open()
        {
            string ID = Session["ID"].ToString();

            var model = db.MonHocs.Where(x => x.TenMH == ID).ToList();
            
          
            return View(model);
        }

        public ActionResult Close()
        {
            //int ID = (int)Session["ID"];
            //var model = db.GiangDays.Where(x => x.Status == false && x.ID_GiangVien == ID);
            return View();
        }
    }
}