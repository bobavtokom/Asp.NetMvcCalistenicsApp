using Calistenics.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Calistenics.Controllers {
    public class ExcercisesController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: Excercises
        public ActionResult Index(string searchExercise, string searchLevel)
        {
            var exercises = from e in db.Excercises
                           select e;
            var levelList = new List<string>();

            var levelsQuery = from e in db.Excercises 
                         orderby e.Level 
                         select e.Level;

            levelList.AddRange(levelsQuery.Distinct());
            ViewBag.searchLevel = new SelectList(levelList);
            
            if(!String.IsNullOrEmpty(searchExercise)) {
                exercises = exercises.Where(e => e.Name.Contains(searchExercise));
            }
            if (!String.IsNullOrEmpty(searchLevel)) {
                exercises = exercises.Where(e => e.Level == searchLevel);
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
