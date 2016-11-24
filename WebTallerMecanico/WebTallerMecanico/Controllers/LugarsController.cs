using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTallerMecanico.Models;

namespace WebTallerMecanico.Controllers
{
    public class LugarsController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: Lugars
        public ActionResult Index()
        {
            return View(db.Lugars.ToList());
        }

        // GET: Lugars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.Lugars.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // GET: Lugars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lugars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ciudad,Lugar1,lugarID")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Lugars.Add(lugar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        // GET: Lugars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.Lugars.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ciudad,Lugar1,lugarID")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugar);
        }

        // GET: Lugars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.Lugars.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lugar lugar = db.Lugars.Find(id);
            db.Lugars.Remove(lugar);
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
