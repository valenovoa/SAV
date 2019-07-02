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
    public class AvionController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: Avion
        public ActionResult Index()
        {
            var aVION = db.AVION.Include(a => a.LINEA_AEREA).Include(a => a.MARCA_AVION).Include(a => a.TIPO_AVION);
            return View(aVION.ToList());
        }

        // GET: Avion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVION aVION = db.AVION.Find(id);
            if (aVION == null)
            {
                return HttpNotFound();
            }
            return View(aVION);
        }

        // GET: Avion/Create
        public ActionResult Create()
        {
            ViewBag.COD_LA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO");
            ViewBag.COD_MARCA = new SelectList(db.MARCA_AVION, "COD_MARCA", "MARCA");
            ViewBag.ID_TIPO = new SelectList(db.TIPO_AVION, "ID_TIPO", "NOM_TIPO");
            return View();
        }

        // POST: Avion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PLACA_AVION,ID_TIPO,COD_MARCA,CAPACIDAD_ASIENTO,COD_LA,ESTADO_AVION")] AVION aVION)
        {
            if (ModelState.IsValid)
            {
                db.AVION.Add(aVION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_LA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO", aVION.COD_LA);
            ViewBag.COD_MARCA = new SelectList(db.MARCA_AVION, "COD_MARCA", "MARCA", aVION.COD_MARCA);
            ViewBag.ID_TIPO = new SelectList(db.TIPO_AVION, "ID_TIPO", "NOM_TIPO", aVION.ID_TIPO);
            return View(aVION);
        }

        // GET: Avion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVION aVION = db.AVION.Find(id);
            if (aVION == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_LA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO", aVION.COD_LA);
            ViewBag.COD_MARCA = new SelectList(db.MARCA_AVION, "COD_MARCA", "MARCA", aVION.COD_MARCA);
            ViewBag.ID_TIPO = new SelectList(db.TIPO_AVION, "ID_TIPO", "NOM_TIPO", aVION.ID_TIPO);
            return View(aVION);
        }

        // POST: Avion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PLACA_AVION,ID_TIPO,COD_MARCA,CAPACIDAD_ASIENTO,COD_LA,ESTADO_AVION")] AVION aVION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aVION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_LA = new SelectList(db.LINEA_AEREA, "COD_LINEA_AEREA", "COD_AEROPUERTO", aVION.COD_LA);
            ViewBag.COD_MARCA = new SelectList(db.MARCA_AVION, "COD_MARCA", "MARCA", aVION.COD_MARCA);
            ViewBag.ID_TIPO = new SelectList(db.TIPO_AVION, "ID_TIPO", "NOM_TIPO", aVION.ID_TIPO);
            return View(aVION);
        }

        // GET: Avion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVION aVION = db.AVION.Find(id);
            if (aVION == null)
            {
                return HttpNotFound();
            }
            return View(aVION);
        }

        // POST: Avion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AVION aVION = db.AVION.Find(id);
            db.AVION.Remove(aVION);
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
