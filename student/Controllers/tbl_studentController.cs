using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using student.Models;

namespace student.Controllers
{
    public class tbl_studentController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_student
        public ActionResult Index()
        {
            return View(db.tbl_student.ToList());
        }

        // GET: tbl_student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_student tbl_student = db.tbl_student.Find(id);
            if (tbl_student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_student);
        }

        // GET: tbl_student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,Degree,Department,Semester,Fees")] tbl_student tbl_student)
        {
            if (ModelState.IsValid)
            {
                db.tbl_student.Add(tbl_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_student);
        }

        // GET: tbl_student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_student tbl_student = db.tbl_student.Find(id);
            if (tbl_student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_student);
        }

        // POST: tbl_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,Degree,Department,Semester,Fees")] tbl_student tbl_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_student);
        }

        // GET: tbl_student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_student tbl_student = db.tbl_student.Find(id);
            if (tbl_student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_student);
        }

        // POST: tbl_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_student tbl_student = db.tbl_student.Find(id);
            db.tbl_student.Remove(tbl_student);
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
