using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAV.Models;

namespace SAV.Controllers
{
    public class GetaweyController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: Getawey
        public ActionResult Index()
        {
            var gETAWEY = db.GETAWEY.Include(g => g.AEROPUERTO).Include(g => g.AVION).Include(g => g.LINEA_AEREA);
            return View(gETAWEY.ToList());
        }

        // GET: Getawey/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GETAWEY gETAWEY = db.GETAWEY.Find(id);
            if (gETAWEY == null)
            {
                return HttpNotFound();
            }
            return View(gETAWEY);
        }

        // GET: Getawey/Create
        public ActionResult Create()
        {
            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO");
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "COD_MARCA");
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO");
            return View();
        }

        // POST: Getawey/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_GETEWAY,NUMERO,COD_AEROPUERTO,PLACA_AVION,FECHA_ABORDAJE,HORA_ABORDAJE,HORA_DESABORDAJE,FECHA_DESABORDAJE,ESTADO_GETAWEY,COD_LINEA_AEREA")] GETAWEY gETAWEY)
        {
            if (ModelState.IsValid)
            {
                db.GETAWEY.Add(gETAWEY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", gETAWEY.COD_AEROPUERTO);
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "COD_MARCA", gETAWEY.PLACA_AVION);
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO", gETAWEY.COD_LINEA_AEREA);
            return View(gETAWEY);
        }

        // GET: Getawey/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GETAWEY gETAWEY = db.GETAWEY.Find(id);
            if (gETAWEY == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", gETAWEY.COD_AEROPUERTO);
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "COD_MARCA", gETAWEY.PLACA_AVION);
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO", gETAWEY.COD_LINEA_AEREA);
            return View(gETAWEY);
        }

        // POST: Getawey/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_GETEWAY,NUMERO,COD_AEROPUERTO,PLACA_AVION,FECHA_ABORDAJE,HORA_ABORDAJE,HORA_DESABORDAJE,FECHA_DESABORDAJE,ESTADO_GETAWEY,COD_LINEA_AEREA")] GETAWEY gETAWEY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gETAWEY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", gETAWEY.COD_AEROPUERTO);
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "COD_MARCA", gETAWEY.PLACA_AVION);
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO", gETAWEY.COD_LINEA_AEREA);
            return View(gETAWEY);
        }

        // GET: Getawey/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GETAWEY gETAWEY = db.GETAWEY.Find(id);
            if (gETAWEY == null)
            {
                return HttpNotFound();
            }
            return View(gETAWEY);
        }

        // POST: Getawey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GETAWEY gETAWEY = db.GETAWEY.Find(id);
            db.GETAWEY.Remove(gETAWEY);
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
