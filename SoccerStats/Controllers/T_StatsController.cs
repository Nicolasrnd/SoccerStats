using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoccerStats.Models;

namespace SoccerStats.Controllers
{
    public class T_StatsController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Stats
        public ActionResult Index()
        {
            return View(db.T_Stats.ToList());
        }

        // GET: T_Stats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Stats t_Stats = db.T_Stats.Find(id);
            if (t_Stats == null)
            {
                return HttpNotFound();
            }
            return View(t_Stats);
        }

        // GET: T_Stats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Stats/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStats,matchJoues,butMarques,passesDecisives")] T_Stats t_Stats)
        {
            if (ModelState.IsValid)
            {
                db.T_Stats.Add(t_Stats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Stats);
        }

        // GET: T_Stats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Stats t_Stats = db.T_Stats.Find(id);
            if (t_Stats == null)
            {
                return HttpNotFound();
            }
            return View(t_Stats);
        }

        // POST: T_Stats/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStats,matchJoues,butMarques,passesDecisives")] T_Stats t_Stats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Stats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Stats);
        }

        // GET: T_Stats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Stats t_Stats = db.T_Stats.Find(id);
            if (t_Stats == null)
            {
                return HttpNotFound();
            }
            return View(t_Stats);
        }

        // POST: T_Stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Stats t_Stats = db.T_Stats.Find(id);
            db.T_Stats.Remove(t_Stats);
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
