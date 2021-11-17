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
    public class T_EntraineurController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Entraineur
        public ActionResult Index()
        {
            var t_Entraineur = db.T_Entraineur.Include(t => t.T_Club);
            return View(t_Entraineur.ToList());
        }

        // GET: T_Entraineur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Entraineur t_Entraineur = db.T_Entraineur.Find(id);
            if (t_Entraineur == null)
            {
                return HttpNotFound();
            }
            return View(t_Entraineur);
        }

        // GET: T_Entraineur/Create
        public ActionResult Create()
        {
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub");
            return View();
        }

        // POST: T_Entraineur/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEntraineur,idClub,nomEntraineur,nationaliteEntraineur")] T_Entraineur t_Entraineur)
        {
            if (ModelState.IsValid)
            {
                db.T_Entraineur.Add(t_Entraineur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Entraineur.idClub);
            return View(t_Entraineur);
        }

        // GET: T_Entraineur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Entraineur t_Entraineur = db.T_Entraineur.Find(id);
            if (t_Entraineur == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Entraineur.idClub);
            return View(t_Entraineur);
        }

        // POST: T_Entraineur/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEntraineur,idClub,nomEntraineur,nationaliteEntraineur")] T_Entraineur t_Entraineur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Entraineur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Entraineur.idClub);
            return View(t_Entraineur);
        }

        // GET: T_Entraineur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Entraineur t_Entraineur = db.T_Entraineur.Find(id);
            if (t_Entraineur == null)
            {
                return HttpNotFound();
            }
            return View(t_Entraineur);
        }

        // POST: T_Entraineur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Entraineur t_Entraineur = db.T_Entraineur.Find(id);
            db.T_Entraineur.Remove(t_Entraineur);
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
