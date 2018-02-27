using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetFinal.Models;

namespace AspNetFinal.Controllers
{
    [AuthorizationFilter]
    public class EmployeesController : Controller
    {
        private AspNetFinalEntities db = new AspNetFinalEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Departament).Include(e => e.Designation).Include(e => e.Gender);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name");
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name");
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,emp_fullname,emp_fathername,emp_dateof_birth,emp_gender_id,emp_phone,emp_address,emp_email,emp_password,emp_dep_id,emp_desig_id,emp_date_of_joining,emp_exit_date,emp_work_status,emp_salary")] Employee employee,HttpPostedFileBase emp_photo, HttpPostedFileBase emp_resume, HttpPostedFileBase emp_offer_letter, HttpPostedFileBase emp_joining_letter, HttpPostedFileBase emp_contact_and_argue, HttpPostedFileBase emp_ID_proof)
        {
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name", employee.emp_dep_id);
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name", employee.emp_desig_id);
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.emp_gender_id);
            if (ModelState.IsValid)
            {
                //foto
                var file_name = Path.GetFileName(emp_photo.FileName);
                if (emp_photo.ContentLength > 0)
                {
                    var file_src = Path.Combine(Server.MapPath("/Uploads/Images"), file_name);
                    emp_photo.SaveAs(file_src);
                }
                employee.emp_photo = file_name;

                //resume
                if (emp_resume != null)
                {
                    if(emp_resume.ContentType!= "application/pdf")
                    {
                        ViewBag.resume_error = "File type Pdf olmalidir";
                        return View();
                    }
                    else
                    {
                        var resume_file = Path.GetFileName(emp_resume.FileName);
                        if (emp_resume.ContentLength > 0)
                        {
                            var resume_src = Path.Combine(Server.MapPath("/Uploads/Documents"), resume_file);
                            emp_resume.SaveAs(resume_src);
                            employee.emp_resume = resume_file;
                        }
                    }
                }

                //offer letter
                if (emp_offer_letter!=null)
                {
                    if (emp_offer_letter.ContentType != "application/pdf")
                    {
                        ViewBag.offer_error = "File type Pdf olmalidir";
                        return View();
                    }
                    else
                    {
                        var offer_file = Path.GetFileName(emp_offer_letter.FileName);
                        if (emp_offer_letter.ContentLength>0)
                        {
                            var offer_src = Path.Combine(Server.MapPath("/Uploads/Documents"), offer_file);
                            emp_offer_letter.SaveAs(offer_src);
                            employee.emp_offer_letter = offer_file;
                        }
                    }
                }

                //joining letter
                if (emp_joining_letter != null)
                {
                    if (emp_joining_letter.ContentType != "application/pdf")
                    {
                        ViewBag.loining_error = "File type Pdf olmalidir";
                        return View();
                    }
                    else
                    {
                        var joining_file = Path.GetFileName(emp_joining_letter.FileName);
                        if (emp_joining_letter.ContentLength > 0)
                        {
                            var joining_src = Path.Combine(Server.MapPath("/Uploads/Documents"), joining_file);
                            emp_joining_letter.SaveAs(joining_src);
                            employee.emp_joining_letter = joining_file;
                        }
                    }
                }

                //contact and argue
                if (emp_contact_and_argue != null)
                {
                    if (emp_contact_and_argue.ContentType != "application/pdf")
                    {
                        ViewBag.contact_error = "File type Pdf olmalidir";
                        return View();
                    }
                    else
                    {
                        var contact_file = Path.GetFileName(emp_contact_and_argue.FileName);
                        if (emp_contact_and_argue.ContentLength > 0)
                        {
                            var contact_src = Path.Combine(Server.MapPath("/Uploads/Documents"), contact_file);
                            emp_contact_and_argue.SaveAs(contact_src);
                            employee.emp_contact_and_argue = contact_file;
                        }
                    }
                }

                //ID proof
                if (emp_ID_proof != null)
                {
                    if (emp_ID_proof.ContentType != "application/pdf")
                    {
                        ViewBag.proof_error = "File type Pdf olmalidir";
                        return View();
                    }
                    else
                    {
                        var idproof_file = Path.GetFileName(emp_ID_proof.FileName);
                        if (emp_ID_proof.ContentLength > 0)
                        {
                            var idproof_src = Path.Combine(Server.MapPath("/Uploads/Documents"), idproof_file);
                            emp_ID_proof.SaveAs(idproof_src);
                            employee.emp_ID_proof = idproof_file;
                        }
                    }
                }

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name", employee.emp_dep_id);
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name", employee.emp_desig_id);
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.emp_gender_id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,emp_fullname,emp_fathername,emp_dateof_birth,emp_gender_id,emp_phone,emp_address,emp_photo,emp_email,emp_password,emp_dep_id,emp_desig_id,emp_date_of_joining,emp_exit_date,emp_work_status,emp_salary,emp_resume,emp_offer_letter,emp_joining_letter,emp_contact_and_argue,emp_ID_proof")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_dep_id = new SelectList(db.Departaments, "id", "depart_name", employee.emp_dep_id);
            ViewBag.emp_desig_id = new SelectList(db.Designations, "id", "desig_name", employee.emp_desig_id);
            ViewBag.emp_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.emp_gender_id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
