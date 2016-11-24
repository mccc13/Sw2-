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
    public class OrdenServiciosController : Controller
    {
        private dbTallerEntities db = new dbTallerEntities();

        // GET: OrdenServicios
        public ActionResult Index()
        {
            var ordenServicios = db.OrdenServicios.Include(o => o.Cliente).Include(o => o.Lugar).Include(o => o.OrdenCompra).Include(o => o.Vehiculo);
            return View(ordenServicios.ToList());
        }

        // GET: OrdenServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenServicio ordenServicio = db.OrdenServicios.Find(id);
            if (ordenServicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenServicio);
        }

        // GET: OrdenServicios/Create
        public ActionResult Create()
        {
            ViewBag.clienteID = new SelectList(db.Clientes, "clienteID", "Correo");
            ViewBag.lugarID = new SelectList(db.Lugars, "lugarID", "Ciudad");
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID");
            ViewBag.vehiculoID = new SelectList(db.Vehiculoes, "vehiculoID", "Color");
            return View();
        }

        // POST: OrdenServicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estado,Fecha,Observacion,Total,ordenServicioID,clienteID,lugarID,ordenCompraID,vehiculoID")] OrdenServicio ordenServicio)
        {
            if (ModelState.IsValid)
            {
                db.OrdenServicios.Add(ordenServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteID = new SelectList(db.Clientes, "clienteID", "Correo", ordenServicio.clienteID);
            ViewBag.lugarID = new SelectList(db.Lugars, "lugarID", "Ciudad", ordenServicio.lugarID);
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID", ordenServicio.ordenCompraID);
            ViewBag.vehiculoID = new SelectList(db.Vehiculoes, "vehiculoID", "Color", ordenServicio.vehiculoID);
            return View(ordenServicio);
        }

        // GET: OrdenServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenServicio ordenServicio = db.OrdenServicios.Find(id);
            if (ordenServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteID = new SelectList(db.Clientes, "clienteID", "Correo", ordenServicio.clienteID);
            ViewBag.lugarID = new SelectList(db.Lugars, "lugarID", "Ciudad", ordenServicio.lugarID);
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID", ordenServicio.ordenCompraID);
            ViewBag.vehiculoID = new SelectList(db.Vehiculoes, "vehiculoID", "Color", ordenServicio.vehiculoID);
            return View(ordenServicio);
        }

        // POST: OrdenServicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estado,Fecha,Observacion,Total,ordenServicioID,clienteID,lugarID,ordenCompraID,vehiculoID")] OrdenServicio ordenServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteID = new SelectList(db.Clientes, "clienteID", "Correo", ordenServicio.clienteID);
            ViewBag.lugarID = new SelectList(db.Lugars, "lugarID", "Ciudad", ordenServicio.lugarID);
            ViewBag.ordenCompraID = new SelectList(db.OrdenCompras, "ordenCompraID", "ordenCompraID", ordenServicio.ordenCompraID);
            ViewBag.vehiculoID = new SelectList(db.Vehiculoes, "vehiculoID", "Color", ordenServicio.vehiculoID);
            return View(ordenServicio);
        }

        // GET: OrdenServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenServicio ordenServicio = db.OrdenServicios.Find(id);
            if (ordenServicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenServicio);
        }

        // POST: OrdenServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenServicio ordenServicio = db.OrdenServicios.Find(id);
            db.OrdenServicios.Remove(ordenServicio);
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
