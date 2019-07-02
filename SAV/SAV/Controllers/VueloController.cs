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
    public class VueloController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: Vuelo
        public ActionResult Index()
        {
            var vUELO = db.VUELO.Include(v => v.AVION).Include(v => v.ITINERARIO).Include(v => v.LINEA_AEREA);
            return View(vUELO.ToList());
        }

        // GET: Vuelo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VUELO vUELO = db.VUELO.Find(id);
            if (vUELO == null)
            {
                return HttpNotFound();
            }
            return View(vUELO);
        }

        // GET: Vuelo/Create
        public ActionResult Create()
        {
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "PLACA_AVION");
            ViewBag.ID_ITINERARIO = new SelectList(db.ITINERARIO, "ID_ITINERARIO", "ItinerarioCompleto");
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "NOM_CORTO");
            return View();
        }

        // POST: Vuelo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_VUELO,COD_LINEA_AEREA,MILLAS_REALES,MILLAS_OTROGADAS,PLACA_AVION,ID_ITINERARIO,FECHA_SALIDA,DISPONIBILIDAD")] VUELO vUELO)
        {
            if (ModelState.IsValid)
            {
                db.VUELO.Add(vUELO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "PLACA_AVION", vUELO.PLACA_AVION);
            ViewBag.ID_ITINERARIO = new SelectList(db.ITINERARIO, "ID_ITINERARIO", "ItinerarioCompleto", vUELO.ID_ITINERARIO);
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "NOM_CORTO", vUELO.COD_LINEA_AEREA);
            return View(vUELO);
        }

        // GET: Vuelo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VUELO vUELO = db.VUELO.Find(id);
            if (vUELO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "PLACA_AVION", vUELO.PLACA_AVION);
            ViewBag.ID_ITINERARIO = new SelectList(db.ITINERARIO, "ID_ITINERARIO", "ItinerarioCompleto", vUELO.ID_ITINERARIO);
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "NOM_CORTO", vUELO.COD_LINEA_AEREA);
            return View(vUELO);
        }

        // POST: Vuelo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_VUELO,COD_LINEA_AEREA,MILLAS_REALES,MILLAS_OTROGADAS,PLACA_AVION,ID_ITINERARIO,FECHA_SALIDA,DISPONIBILIDAD")] VUELO vUELO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vUELO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PLACA_AVION = new SelectList(db.AVION, "PLACA_AVION", "PLACA_AVION", vUELO.PLACA_AVION);
            ViewBag.ID_ITINERARIO = new SelectList(db.ITINERARIO, "ID_ITINERARIO", "ItinerarioCompleto", vUELO.ID_ITINERARIO);
            ViewBag.COD_LINEA_AEREA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "NOM_CORTO", vUELO.COD_LINEA_AEREA);
            return View(vUELO);
        }

        // GET: Vuelo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VUELO vUELO = db.VUELO.Find(id);
            if (vUELO == null)
            {
                return HttpNotFound();
            }
            return View(vUELO);
        }

        // POST: Vuelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VUELO vUELO = db.VUELO.Find(id);
            db.VUELO.Remove(vUELO);
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
