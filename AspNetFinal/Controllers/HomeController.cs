using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetFinal.Models;


namespace AspNetFinal.Controllers
{
    [AuthorizationFilterUser]
    public class HomeController : Controller
    {
        AspNetFinalEntities db = new AspNetFinalEntities();
        UserViewModel vm = new UserViewModel();
        public ActionResult Index()
        {
            vm._employee = LoginUserController.log_emp;
            vm._holidays = db.Holidays.ToList();
            vm._award = db.Awards.ToList();
            vm._leave_app = db.Leave_App.ToList();
            vm._notice = db.Notice_Board.ToList();


            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(Leave_App leave)
        {
            vm._employee = LoginUserController.log_emp;
            vm._holidays = db.Holidays.ToList();
            vm._award = db.Awards.ToList();
            vm._leave_app = db.Leave_App.ToList();
            vm._notice = db.Notice_Board.ToList();

            leave.leave_emp_id = vm._employee.id;
            leave.leave_status_id = 1;
            db.Leave_App.Add(leave);
            db.SaveChanges();
            return View(vm);
        }


        public ActionResult MYLeave()
        {
            vm._leave_app = db.Leave_App.ToList();
            vm._employee = LoginUserController.log_emp;
            vm._leave_status = db.Leave_status.Where(l => l.id == LoginUserController.log_emp.id).ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult MYLeave1(Leave_App leave_app)
        {
            leave_app.leave_emp_id = LoginUserController.log_emp.id;
            leave_app.leave_status_id = 1;
            db.Leave_App.Add(leave_app);
            db.SaveChanges();
            return RedirectToAction("MYLeave");
        }



        public ActionResult Changepass(string oldpass, string newpass)
        {
            Employee employee = db.Employees.Find(LoginUserController.log_emp.id);

            if (oldpass == employee.emp_password)
            {

                employee.emp_password = newpass;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}