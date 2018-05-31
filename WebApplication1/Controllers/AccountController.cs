using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        SEP_DTBEntities1 db = new SEP_DTBEntities1();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.GiangViens.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["ID"] = user.ID;
                    Session["name"] = user.TenGV;
                    Session["monhoc"] = user.GiangDays.FirstOrDefault(x => x.ID_GiangVien == user.ID).ID_MonHoc;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session["ID"] = null;
            Session["name"] = null;
            Session["monhoc"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}
