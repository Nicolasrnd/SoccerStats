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
    public class T_ClubController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Club
        public ActionResult Index()
        {
            var t_Club = db.T_Club.Include(t => t.T_Championnat);
            return View(t_Club.ToList());
        }

        // GET: T_Club/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Club t_Club = db.T_Club.Find(id);
            if (t_Club == null)
            {
                return HttpNotFound();
            }
            return View(t_Club);
        }

        // GET: T_Club/Create
        public ActionResult Create()
        {
            ViewBag.idChampionnat = new SelectList(db.T_Championnat, "idChampionnat", "libelleChamp");
            return View();
        }

        // POST: T_Club/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClub,idChampionnat,nomClub")] T_Club t_Club)
        {
            if (ModelState.IsValid)
            {
                db.T_Club.Add(t_Club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChampionnat = new SelectList(db.T_Championnat, "idChampionnat", "libelleChamp", t_Club.idChampionnat);
            return View(t_Club);
        }

        // GET: T_Club/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Club t_Club = db.T_Club.Find(id);
            if (t_Club == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChampionnat = new SelectList(db.T_Championnat, "idChampionnat", "libelleChamp", t_Club.idChampionnat);
            return View(t_Club);
        }

        // POST: T_Club/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClub,idChampionnat,nomClub")] T_Club t_Club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChampionnat = new SelectList(db.T_Championnat, "idChampionnat", "libelleChamp", t_Club.idChampionnat);
            return View(t_Club);
        }

        // GET: T_Club/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Club t_Club = db.T_Club.Find(id);
            if (t_Club == null)
            {
                return HttpNotFound();
            }
            return View(t_Club);
        }

        // POST: T_Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Club t_Club = db.T_Club.Find(id);
            db.T_Club.Remove(t_Club);
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
