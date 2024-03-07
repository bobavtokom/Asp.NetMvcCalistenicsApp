using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Calistenics.Models;

namespace Calistenics.Controllers
{
    public class ExcercisesController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: Excercises
        public ActionResult Index(string searchExercise)
        {
            var exercises = from e in db.Excercises
                           select e;
            if(!String.IsNullOrEmpty(searchExercise)) {
                exercises = exercises.Where(e => e.Name.Contains(searchExercise));
            }
            return View(exercises);
        }

        // GET: Excercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercise excercise = db.Excercises.Find(id);
            if (excercise == null)
            {
                return HttpNotFound();
            }
            return View(excercise);
        }

        // GET: Excercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Level")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                db.Excercises.Add(excercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excercise);
        }

        // GET: Excercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercise excercise = db.Excercises.Find(id);
            if (excercise == null)
            {
                return HttpNotFound();
            }
            return View(excercise);
        }

        // POST: Excercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Level")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excercise);
        }

        // GET: Excercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercise excercise = db.Excercises.Find(id);
            if (excercise == null)
            {
                return HttpNotFound();
            }
            return View(excercise);
        }

        // POST: Excercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Excercise excercise = db.Excercises.Find(id);
            db.Excercises.Remove(excercise);
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
