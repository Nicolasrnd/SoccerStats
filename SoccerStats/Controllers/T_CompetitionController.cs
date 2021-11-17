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
    public class T_CompetitionController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Competition
        public ActionResult Index()
        {
            return View(db.T_Competition.ToList());
        }

        // GET: T_Competition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Competition t_Competition = db.T_Competition.Find(id);
            if (t_Competition == null)
            {
                return HttpNotFound();
            }
            return View(t_Competition);
        }

        // GET: T_Competition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Competition/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompetition,libelleCompetition")] T_Competition t_Competition)
        {
            if (ModelState.IsValid)
            {
                db.T_Competition.Add(t_Competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Competition);
        }

        // GET: T_Competition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Competition t_Competition = db.T_Competition.Find(id);
            if (t_Competition == null)
            {
                return HttpNotFound();
            }
            return View(t_Competition);
        }

        // POST: T_Competition/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompetition,libelleCompetition")] T_Competition t_Competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Competition);
        }

        // GET: T_Competition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Competition t_Competition = db.T_Competition.Find(id);
            if (t_Competition == null)
            {
                return HttpNotFound();
            }
            return View(t_Competition);
        }

        // POST: T_Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Competition t_Competition = db.T_Competition.Find(id);
            db.T_Competition.Remove(t_Competition);
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
