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
    public class AeropuertoController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: Aeropuerto
        public ActionResult Index()
        {
            var aEROPUERTO = db.AEROPUERTO.Include(a => a.CIUDAD);
            return View(aEROPUERTO.ToList());
        }

        // GET: Aeropuerto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROPUERTO aEROPUERTO = db.AEROPUERTO.Find(id);
            if (aEROPUERTO == null)
            {
                return HttpNotFound();
            }
            return View(aEROPUERTO);
        }

        // GET: Aeropuerto/Create
        public ActionResult Create()
        {
            ViewBag.COD_CIUDAD = new SelectList(db.CIUDAD, "COD_CIUDAD", "NOM_CIUDAD");
            return View();
        }

        // POST: Aeropuerto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AEROPUERTO,NOM_AEROPUERTO,TELEFONO,COD_CIUDAD")] AEROPUERTO aEROPUERTO)
        {
            if (ModelState.IsValid)
            {
                db.AEROPUERTO.Add(aEROPUERTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CIUDAD = new SelectList(db.CIUDAD, "COD_CIUDAD", "NOM_CIUDAD", aEROPUERTO.COD_CIUDAD);
            return View(aEROPUERTO);
        }

        // GET: Aeropuerto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROPUERTO aEROPUERTO = db.AEROPUERTO.Find(id);
            if (aEROPUERTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CIUDAD = new SelectList(db.CIUDAD, "COD_CIUDAD", "NOM_CIUDAD", aEROPUERTO.COD_CIUDAD);
            return View(aEROPUERTO);
        }

        // POST: Aeropuerto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AEROPUERTO,NOM_AEROPUERTO,TELEFONO,COD_CIUDAD")] AEROPUERTO aEROPUERTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aEROPUERTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CIUDAD = new SelectList(db.CIUDAD, "COD_CIUDAD", "NOM_CIUDAD", aEROPUERTO.COD_CIUDAD);
            return View(aEROPUERTO);
        }

        // GET: Aeropuerto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROPUERTO aEROPUERTO = db.AEROPUERTO.Find(id);
            if (aEROPUERTO == null)
            {
                return HttpNotFound();
            }
            return View(aEROPUERTO);
        }

        // POST: Aeropuerto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AEROPUERTO aEROPUERTO = db.AEROPUERTO.Find(id);
            db.AEROPUERTO.Remove(aEROPUERTO);
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
