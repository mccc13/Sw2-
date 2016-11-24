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
    public class TipoServiciosController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: TipoServicios
        public ActionResult Index()
        {
            return View(db.TipoServicios.ToList());
        }

        // GET: TipoServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicio tipoServicio = db.TipoServicios.Find(id);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }

        // GET: TipoServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Servicio,tipoServiciosID")] TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                db.TipoServicios.Add(tipoServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoServicio);
        }

        // GET: TipoServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicio tipoServicio = db.TipoServicios.Find(id);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }

        // POST: TipoServicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Servicio,tipoServiciosID")] TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoServicio);
        }

        // GET: TipoServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicio tipoServicio = db.TipoServicios.Find(id);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }

        // POST: TipoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoServicio tipoServicio = db.TipoServicios.Find(id);
            db.TipoServicios.Remove(tipoServicio);
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
