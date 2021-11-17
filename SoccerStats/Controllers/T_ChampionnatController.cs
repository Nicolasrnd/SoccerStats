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
    public class T_ChampionnatController : Controller
    {
        private BD_SoccerStatsEntities db = new BD_SoccerStatsEntities();

        // GET: T_Championnat
        public ActionResult Index()
        {
            return View(db.T_Championnat.ToList());
        }

        // GET: T_Championnat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Championnat t_Championnat = db.T_Championnat.Find(id);
            if (t_Championnat == null)
            {
                return HttpNotFound();
            }
            return View(t_Championnat);
        }

        // GET: T_Championnat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Championnat/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idChampionnat,libelleChamp")] T_Championnat t_Championnat)
        {
            if (ModelState.IsValid)
            {
                db.T_Championnat.Add(t_Championnat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Championnat);
        }

        // GET: T_Championnat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Championnat t_Championnat = db.T_Championnat.Find(id);
            if (t_Championnat == null)
            {
                return HttpNotFound();
            }
            return View(t_Championnat);
        }

        // POST: T_Championnat/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idChampionnat,libelleChamp")] T_Championnat t_Championnat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Championnat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Championnat);
        }

        // GET: T_Championnat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Championnat t_Championnat = db.T_Championnat.Find(id);
            if (t_Championnat == null)
            {
                return HttpNotFound();
            }
            return View(t_Championnat);
        }

        // POST: T_Championnat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Championnat t_Championnat = db.T_Championnat.Find(id);
            db.T_Championnat.Remove(t_Championnat);
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
