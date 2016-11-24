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
    public class DetalleServiciosController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: DetalleServicios
        public ActionResult Index()
        {
            var detalleServicios = db.DetalleServicios.Include(d => d.OrdenServicio).Include(d => d.TipoServicio);
            return View(detalleServicios.ToList());
        }

        // GET: DetalleServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleServicio detalleServicio = db.DetalleServicios.Find(id);
            if (detalleServicio == null)
            {
                return HttpNotFound();
            }
            return View(detalleServicio);
        }

        // GET: DetalleServicios/Create
        public ActionResult Create()
        {
            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado");
            ViewBag.tipoServiciosID = new SelectList(db.TipoServicios, "tipoServiciosID", "Servicio");
            return View();
        }

        // POST: DetalleServicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Costo,Tiempo,detalleServicioID,tipoServiciosID,ordenServicioID")] DetalleServicio detalleServicio)
        {
            if (ModelState.IsValid)
            {
                db.DetalleServicios.Add(detalleServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado", detalleServicio.ordenServicioID);
            ViewBag.tipoServiciosID = new SelectList(db.TipoServicios, "tipoServiciosID", "Servicio", detalleServicio.tipoServiciosID);
            return View(detalleServicio);
        }

        // GET: DetalleServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleServicio detalleServicio = db.DetalleServicios.Find(id);
            if (detalleServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado", detalleServicio.ordenServicioID);
            ViewBag.tipoServiciosID = new SelectList(db.TipoServicios, "tipoServiciosID", "Servicio", detalleServicio.tipoServiciosID);
            return View(detalleServicio);
        }

        // POST: DetalleServicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Costo,Tiempo,detalleServicioID,tipoServiciosID,ordenServicioID")] DetalleServicio detalleServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado", detalleServicio.ordenServicioID);
            ViewBag.tipoServiciosID = new SelectList(db.TipoServicios, "tipoServiciosID", "Servicio", detalleServicio.tipoServiciosID);
            return View(detalleServicio);
        }

        // GET: DetalleServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleServicio detalleServicio = db.DetalleServicios.Find(id);
            if (detalleServicio == null)
            {
                return HttpNotFound();
            }
            return View(detalleServicio);
        }

        // POST: DetalleServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleServicio detalleServicio = db.DetalleServicios.Find(id);
            db.DetalleServicios.Remove(detalleServicio);
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
