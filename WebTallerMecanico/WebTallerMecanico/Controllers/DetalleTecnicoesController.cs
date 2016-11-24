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
    public class DetalleTecnicoesController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: DetalleTecnicoes
        public ActionResult Index()
        {
            var detalleTecnicoes = db.DetalleTecnicoes.Include(d => d.OrdenServicio).Include(d => d.Tecnico);
            return View(detalleTecnicoes.ToList());
        }

        // GET: DetalleTecnicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleTecnico detalleTecnico = db.DetalleTecnicoes.Find(id);
            if (detalleTecnico == null)
            {
                return HttpNotFound();
            }
            return View(detalleTecnico);
        }

        // GET: DetalleTecnicoes/Create
        public ActionResult Create()
        {
            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado");
            ViewBag.tecnicoID = new SelectList(db.Tecnicoes, "tecnicoID", "Nombre");
            return View();
        }

        // POST: DetalleTecnicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion,detalleTecnicoID,tecnicoID,ordenServicioID")] DetalleTecnico detalleTecnico)
        {
            if (ModelState.IsValid)
            {
                db.DetalleTecnicoes.Add(detalleTecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado", detalleTecnico.ordenServicioID);
            ViewBag.tecnicoID = new SelectList(db.Tecnicoes, "tecnicoID", "Nombre", detalleTecnico.tecnicoID);
            return View(detalleTecnico);
        }

        // GET: DetalleTecnicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleTecnico detalleTecnico = db.DetalleTecnicoes.Find(id);
            if (detalleTecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado", detalleTecnico.ordenServicioID);
            ViewBag.tecnicoID = new SelectList(db.Tecnicoes, "tecnicoID", "Nombre", detalleTecnico.tecnicoID);
            return View(detalleTecnico);
        }

        // POST: DetalleTecnicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Descripcion,detalleTecnicoID,tecnicoID,ordenServicioID")] DetalleTecnico detalleTecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleTecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ordenServicioID = new SelectList(db.OrdenServicios, "ordenServicioID", "Estado", detalleTecnico.ordenServicioID);
            ViewBag.tecnicoID = new SelectList(db.Tecnicoes, "tecnicoID", "Nombre", detalleTecnico.tecnicoID);
            return View(detalleTecnico);
        }

        // GET: DetalleTecnicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleTecnico detalleTecnico = db.DetalleTecnicoes.Find(id);
            if (detalleTecnico == null)
            {
                return HttpNotFound();
            }
            return View(detalleTecnico);
        }

        // POST: DetalleTecnicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleTecnico detalleTecnico = db.DetalleTecnicoes.Find(id);
            db.DetalleTecnicoes.Remove(detalleTecnico);
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
