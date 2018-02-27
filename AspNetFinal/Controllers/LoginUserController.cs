using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetFinal.Models;


namespace AspNetFinal.Controllers
{
    public class LoginUserController : Controller
    {
        AspNetFinalEntities db = new AspNetFinalEntities();
        // GET: LoginUser

        public static Employee log_emp;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Employee emp)
        {
            log_emp = db.Employees.Where(n => n.emp_email == emp.emp_email).FirstOrDefault();           
            if (log_emp.emp_email == emp.emp_email)
            {
                if (log_emp.emp_password == emp.emp_password)
                {
                    Session["user_email"] = log_emp.emp_email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult LogOut()
        {
            Session["user_email"] = null;
            return RedirectToAction("Index");
        }


    }
}