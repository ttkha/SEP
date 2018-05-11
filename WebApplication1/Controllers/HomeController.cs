using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        SEPEntities1 db = new SEPEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.BangUsers.FirstOrDefault(x => x.UserName == username);
            if (user != null)
            {
                if (user.PassWord.Equals(password))
                {
                    Session["ID"] = user.MaGV;
                    
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.mgs = "tai khoang khong ton tai";
            }
            return View();
        }
        public ActionResult Logout()
        {
            var user = db.Users;
            if (user != null)
            {
                Session["FullName"] = null;
                Session["UserID"] = null;
            }
            return RedirectToAction("Login", "Home");
        }



    }
}