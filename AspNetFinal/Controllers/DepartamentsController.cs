using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetFinal.Models;

namespace AspNetFinal.Controllers
{
    [AuthorizationFilter]
    public class DepartamentsController : Controller
    {
        private AspNetFinalEntities db = new AspNetFinalEntities();

        // GET: Departaments
        public ActionResult Index()
        {
            //ViewBag.designation = db.Designations.ToList();
            return View(db.Departaments.ToList());
        }

        // GET: Departaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            ViewBag.des = db.Designations.Where(d => d.depart_id == id).ToList();
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // GET: Departaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Departament departament, FormCollection designation)
        {
            if (ModelState.IsValid)
            {                   
                                 
                db.Departaments.Add(departament);
                db.SaveChanges();


                int dep_id = db.Departaments.Where(e => e.depart_name == departament.depart_name).First().id;
                Designation desig = new Designation();
                List<string> collec = designation.GetValues("des_name").ToList();
                foreach (var item in collec)
                {
                    desig.depart_id = dep_id;
                    desig.desig_name= item;
                    db.Designations.Add(desig);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

                
            }

            return View(departament);
        }

        // GET: Departaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            ViewBag.des = db.Designations.Where(d => d.depart_id == id).ToList();
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,depart_name")] Departament departament,FormCollection designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departament).State = EntityState.Modified;
                db.SaveChanges();
                List<Designation> list= db.Designations.Where(d => d.depart_id == departament.id).ToList();
                List<string> collec = designation.GetValues("des_name").ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].desig_name = collec[i];
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            ViewBag.des = db.Designations.Where(d => d.depart_id == id).ToList();
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departament departament = db.Departaments.Find(id);
            List<Designation> dlist = db.Designations.Where(d => d.depart_id == id).ToList();
            foreach (var item in dlist)
            {
                db.Designations.Remove(item);
                db.SaveChanges();
            }
            db.Departaments.Remove(departament);
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
