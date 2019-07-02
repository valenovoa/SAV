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
    public class ItinerariosController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: Itinerarios
        public ActionResult Index()
        {
            var iTINERARIO = db.ITINERARIO.Include(i => i.AEROPUERTO).Include(i => i.AEROPUERTO1);
            return View(iTINERARIO.ToList());
        }

        // GET: Itinerarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITINERARIO iTINERARIO = db.ITINERARIO.Find(id);
            if (iTINERARIO == null)
            {
                return HttpNotFound();
            }
            return View(iTINERARIO);
        }

        // GET: Itinerarios/Create
        public ActionResult Create()
        {
            ViewBag.DESTINO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO");
            ViewBag.ORIGEN = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO");
            return View();
        }

        // POST: Itinerarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ITINERARIO,ORIGEN,DESTINO,HORA_SALIDA,HORA_LLEGADA")] ITINERARIO iTINERARIO)
        {
            if (ModelState.IsValid)
            {
                db.ITINERARIO.Add(iTINERARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DESTINO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", iTINERARIO.DESTINO);
            ViewBag.ORIGEN = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", iTINERARIO.ORIGEN);
            return View(iTINERARIO);
        }

        // GET: Itinerarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITINERARIO iTINERARIO = db.ITINERARIO.Find(id);
            if (iTINERARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.DESTINO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", iTINERARIO.DESTINO);
            ViewBag.ORIGEN = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", iTINERARIO.ORIGEN);
            return View(iTINERARIO);
        }

        // POST: Itinerarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ITINERARIO,ORIGEN,DESTINO,HORA_SALIDA,HORA_LLEGADA")] ITINERARIO iTINERARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTINERARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DESTINO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", iTINERARIO.DESTINO);
            ViewBag.ORIGEN = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", iTINERARIO.ORIGEN);
            return View(iTINERARIO);
        }

        // GET: Itinerarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITINERARIO iTINERARIO = db.ITINERARIO.Find(id);
            if (iTINERARIO == null)
            {
                return HttpNotFound();
            }
            return View(iTINERARIO);
        }

        // POST: Itinerarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITINERARIO iTINERARIO = db.ITINERARIO.Find(id);
            db.ITINERARIO.Remove(iTINERARIO);
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
