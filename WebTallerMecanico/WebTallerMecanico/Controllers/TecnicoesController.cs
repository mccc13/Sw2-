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
    public class TecnicoesController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: Tecnicoes
        public ActionResult Index()
        {
            var tecnicoes = db.Tecnicoes.Include(t => t.Especialidad);
            return View(tecnicoes.ToList());
        }

        // GET: Tecnicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnicoes.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // GET: Tecnicoes/Create
        public ActionResult Create()
        {
            ViewBag.especialidadID = new SelectList(db.Especialidads, "especialidadID", "Especialidad1");
            return View();
        }

        // POST: Tecnicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ci,Nombre,Telefono,tecnicoID,especialidadID")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Tecnicoes.Add(tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.especialidadID = new SelectList(db.Especialidads, "especialidadID", "Especialidad1", tecnico.especialidadID);
            return View(tecnico);
        }

        // GET: Tecnicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnicoes.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.especialidadID = new SelectList(db.Especialidads, "especialidadID", "Especialidad1", tecnico.especialidadID);
            return View(tecnico);
        }

        // POST: Tecnicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ci,Nombre,Telefono,tecnicoID,especialidadID")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.especialidadID = new SelectList(db.Especialidads, "especialidadID", "Especialidad1", tecnico.especialidadID);
            return View(tecnico);
        }

        // GET: Tecnicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnicoes.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnico tecnico = db.Tecnicoes.Find(id);
            db.Tecnicoes.Remove(tecnico);
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
