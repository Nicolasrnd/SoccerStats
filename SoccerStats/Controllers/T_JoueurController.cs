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
    public class T_JoueurController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Joueur
        public ActionResult Index()
        {
            var t_Joueur = db.T_Joueur.Include(t => t.T_Club).Include(t => t.T_Stats);
            return View(t_Joueur.ToList());
        }

        // GET: T_Joueur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Joueur t_Joueur = db.T_Joueur.Find(id);
            if (t_Joueur == null)
            {
                return HttpNotFound();
            }
            return View(t_Joueur);
        }

        // GET: T_Joueur/Create
        public ActionResult Create()
        {
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub");
            ViewBag.idStats = new SelectList(db.T_Stats, "idStats", "idStats");
            return View();
        }

        // POST: T_Joueur/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJoueur,idStats,idClub,nomJoueur,prenomJoueur,ageJoueur,poidsJoueurKg,tailleJoueurCm,nationaliteJoueur")] T_Joueur t_Joueur)
        {
            if (ModelState.IsValid)
            {
                db.T_Joueur.Add(t_Joueur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Joueur.idClub);
            ViewBag.idStats = new SelectList(db.T_Stats, "idStats", "idStats", t_Joueur.idStats);
            return View(t_Joueur);
        }

        // GET: T_Joueur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Joueur t_Joueur = db.T_Joueur.Find(id);
            if (t_Joueur == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Joueur.idClub);
            ViewBag.idStats = new SelectList(db.T_Stats, "idStats", "idStats", t_Joueur.idStats);
            return View(t_Joueur);
        }

        // POST: T_Joueur/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJoueur,idStats,idClub,nomJoueur,prenomJoueur,ageJoueur,poidsJoueurKg,tailleJoueurCm,nationaliteJoueur")] T_Joueur t_Joueur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Joueur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Joueur.idClub);
            ViewBag.idStats = new SelectList(db.T_Stats, "idStats", "idStats", t_Joueur.idStats);
            return View(t_Joueur);
        }

        // GET: T_Joueur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Joueur t_Joueur = db.T_Joueur.Find(id);
            if (t_Joueur == null)
            {
                return HttpNotFound();
            }
            return View(t_Joueur);
        }

        // POST: T_Joueur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Joueur t_Joueur = db.T_Joueur.Find(id);
            db.T_Joueur.Remove(t_Joueur);
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
