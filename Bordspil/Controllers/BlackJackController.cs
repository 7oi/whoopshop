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
    public class BlackJackController : Controller
    {
        private AppDataContext db = new AppDataContext();

        //
        // GET: /BlackJack/

        public ActionResult Index()
        {
            return View(db.BlackJackInstances.ToList());
        }

        //
        // GET: /BlackJack/Details/5

        public ActionResult Details(int id = 0)
        {
            BJ bj = db.BlackJackInstances.Find(id);
            if (bj == null)
            {
                return HttpNotFound();
            }
            return View(bj);
        }

        //
        // GET: /BlackJack/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BlackJack/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BJ bj)
        {
            if (ModelState.IsValid)
            {
                db.BlackJackInstances.Add(bj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bj);
        }

        //
        // GET: /BlackJack/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BJ bj = db.BlackJackInstances.Find(id);
            if (bj == null)
            {
                return HttpNotFound();
            }
            return View(bj);
        }

        //
        // POST: /BlackJack/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BJ bj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bj);
        }

        //
        // GET: /BlackJack/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BJ bj = db.BlackJackInstances.Find(id);
            if (bj == null)
            {
                return HttpNotFound();
            }
            return View(bj);
        }

        //
        // POST: /BlackJack/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BJ bj = db.BlackJackInstances.Find(id);
            db.BlackJackInstances.Remove(bj);
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