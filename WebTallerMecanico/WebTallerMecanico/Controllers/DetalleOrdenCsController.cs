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
    public class DetalleOrdenCsController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: DetalleOrdenCs
        public ActionResult Index()
        {
            var detalleOrdenCs = db.DetalleOrdenCs.Include(d => d.Material).Include(d => d.OrdenCompra);
            return View(detalleOrdenCs.ToList());
        }

        // GET: DetalleOrdenCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrdenC detalleOrdenC = db.DetalleOrdenCs.Find(id);
            if (detalleOrdenC == null)
            {
                return HttpNotFound();
            }
            return View(detalleOrdenC);
        }

        // GET: DetalleOrdenCs/Create
        public ActionResult Create()
        {
            ViewBag.materialID = new SelectList(db.Materials, "materialID", "Descripcion");
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID");
            return View();
        }

        // POST: DetalleOrdenCs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cantidad,Subtotal,detalleOrdenCID,materialID,ordenCompraID")] DetalleOrdenC detalleOrdenC)
        {
            if (ModelState.IsValid)
            {
                db.DetalleOrdenCs.Add(detalleOrdenC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.materialID = new SelectList(db.Materials, "materialID", "Descripcion", detalleOrdenC.materialID);
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID", detalleOrdenC.ordenCompraID);
            return View(detalleOrdenC);
        }

        // GET: DetalleOrdenCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrdenC detalleOrdenC = db.DetalleOrdenCs.Find(id);
            if (detalleOrdenC == null)
            {
                return HttpNotFound();
            }
            ViewBag.materialID = new SelectList(db.Materials, "materialID", "Descripcion", detalleOrdenC.materialID);
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID", detalleOrdenC.ordenCompraID);
            return View(detalleOrdenC);
        }

        // POST: DetalleOrdenCs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cantidad,Subtotal,detalleOrdenCID,materialID,ordenCompraID")] DetalleOrdenC detalleOrdenC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleOrdenC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.materialID = new SelectList(db.Materials, "materialID", "Descripcion", detalleOrdenC.materialID);
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID", detalleOrdenC.ordenCompraID);
            return View(detalleOrdenC);
        }

        // GET: DetalleOrdenCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrdenC detalleOrdenC = db.DetalleOrdenCs.Find(id);
            if (detalleOrdenC == null)
            {
                return HttpNotFound();
            }
            return View(detalleOrdenC);
        }

        // POST: DetalleOrdenCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleOrdenC detalleOrdenC = db.DetalleOrdenCs.Find(id);
            db.DetalleOrdenCs.Remove(detalleOrdenC);
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
