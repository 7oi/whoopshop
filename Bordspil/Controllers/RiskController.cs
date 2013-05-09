using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordspil.Models;

namespace Bordspil.Controllers
{
    public class RiskController : Controller
    {
        private GameContext db = new GameContext();

        //
        // GET: /Risk/

        public ActionResult Index()
        {
            return View(db.RiskInstances.ToList());
        }

        //
        // GET: /Risk/Details/5

        public ActionResult Details(int id = 0)
        {
            Risk risk = db.RiskInstances.Find(id);
            if (risk == null)
            {
                return HttpNotFound();
            }
            return View(risk);
        }

        //
        // GET: /Risk/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Risk/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Risk risk)
        {
            if (ModelState.IsValid)
            {
                db.RiskInstances.Add(risk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(risk);
        }

        //
        // GET: /Risk/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Risk risk = db.RiskInstances.Find(id);
            if (risk == null)
            {
                return HttpNotFound();
            }
            return View(risk);
        }

        //
        // POST: /Risk/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Risk risk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(risk);
        }

        //
        // GET: /Risk/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Risk risk = db.RiskInstances.Find(id);
            if (risk == null)
            {
                return HttpNotFound();
            }
            return View(risk);
        }

        //
        // POST: /Risk/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Risk risk = db.RiskInstances.Find(id);
            db.RiskInstances.Remove(risk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}