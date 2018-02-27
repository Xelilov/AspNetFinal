using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetFinal.Models;
using System.Web.Security;


namespace AspNetFinal.Controllers
{
    
    public class LoginAdminController : Controller
    {
        AspNetFinalEntities db = new AspNetFinalEntities();
        // GET: LoginAdmin
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult LogIn()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult LogIn(Admin adm)
        {
            using(AspNetFinalEntities db = new AspNetFinalEntities())
            {
                var user = db.Admins.Where(a => a.admin_email.Equals(adm.admin_email) && a.admin_password.Equals(adm.admin_password)).FirstOrDefault();
                Session["a_email"] = adm.admin_email;
                return RedirectToAction("Index","Admin");
            }
        }

        public ActionResult LogOut()
        {
            Session["a_email"] = null;
            return RedirectToAction("Index");
        }

















        //[HttpPost]
        //public ActionResult LogIn(FormCollection frm)
        //{  
        //    string a_email= frm["admin_email"];
        //    string a_password= frm["admin_email"];
        //    var count = db.Admins.Where(e => e.admin_email == a_email&&e.admin_password==a_password).Count();           
        //    if (count>0)
        //    {
        //        var user = db.Admins.First(e => e.admin_email == a_email);
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");

        //    }
        //}       

        //public ActionResult LogOut()
        //{           
        //    return RedirectToAction("Index");
        //}
    }
}