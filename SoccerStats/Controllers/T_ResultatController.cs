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
    public class T_ResultatController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Resultat
        public ActionResult Index()
        {
            var t_Resultat = db.T_Resultat.Include(t => t.T_Club).Include(t => t.T_Competition);
            return View(t_Resultat.ToList());
        }

        // GET: T_Resultat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Resultat t_Resultat = db.T_Resultat.Find(id);
            if (t_Resultat == null)
            {
                return HttpNotFound();
            }
            return View(t_Resultat);
        }

        // GET: T_Resultat/Create
        public ActionResult Create()
        {
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub");
            ViewBag.idCompetition = new SelectList(db.T_Competition, "idCompetition", "libelleCompetition");
            return View();
        }

        // POST: T_Resultat/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idResultat,idClub,idCompetition,clubDomicile,clubExterieur,scoreDomicile,scoreExterieur,victoireDomicile,victoireExterieur")] T_Resultat t_Resultat)
        {
            if (ModelState.IsValid)
            {
                db.T_Resultat.Add(t_Resultat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Resultat.idClub);
            ViewBag.idCompetition = new SelectList(db.T_Competition, "idCompetition", "libelleCompetition", t_Resultat.idCompetition);
            return View(t_Resultat);
        }

        // GET: T_Resultat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Resultat t_Resultat = db.T_Resultat.Find(id);
            if (t_Resultat == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Resultat.idClub);
            ViewBag.idCompetition = new SelectList(db.T_Competition, "idCompetition", "libelleCompetition", t_Resultat.idCompetition);
            return View(t_Resultat);
        }

        // POST: T_Resultat/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idResultat,idClub,idCompetition,clubDomicile,clubExterieur,scoreDomicile,scoreExterieur,victoireDomicile,victoireExterieur")] T_Resultat t_Resultat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Resultat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.T_Club, "idClub", "nomClub", t_Resultat.idClub);
            ViewBag.idCompetition = new SelectList(db.T_Competition, "idCompetition", "libelleCompetition", t_Resultat.idCompetition);
            return View(t_Resultat);
        }

        // GET: T_Resultat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Resultat t_Resultat = db.T_Resultat.Find(id);
            if (t_Resultat == null)
            {
                return HttpNotFound();
            }
            return View(t_Resultat);
        }

        // POST: T_Resultat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Resultat t_Resultat = db.T_Resultat.Find(id);
            db.T_Resultat.Remove(t_Resultat);
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
