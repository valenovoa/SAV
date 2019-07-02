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
    public class LineaAereaController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: LineaAerea
        public ActionResult Index()
        {
            var lINEA_AEREA = db.LINEA_AEREA.Include(l => l.AEROPUERTO).Include(l => l.PAIS);
            return View(lINEA_AEREA.ToList());
        }

        // GET: LineaAerea/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEA_AEREA lINEA_AEREA = db.LINEA_AEREA.Find(id);
            if (lINEA_AEREA == null)
            {
                return HttpNotFound();
            }
            return View(lINEA_AEREA);
        }

        // GET: LineaAerea/Create
        public ActionResult Create()
        {
            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO");
            ViewBag.COD_PAIS = new SelectList(db.PAIS, "COD_PAIS", "NOM_PAIS");
            return View();
        }

        // POST: LineaAerea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_LINEA_AEREA,COD_AEROPUERTO,NOM_OFICIAL,NOM_CORTO,NOM_REPRESENTANTE,COD_PAIS,URL,FACEBOOK,TWITTER,INSTAGRAM,YOUTUBE,EMAIL,FECHA_FUNDACION,ESTADO_LA")] LINEA_AEREA lINEA_AEREA)
        {
            if (ModelState.IsValid)
            {
                db.LINEA_AEREA.Add(lINEA_AEREA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", lINEA_AEREA.COD_AEROPUERTO);
            ViewBag.COD_PAIS = new SelectList(db.PAIS, "COD_PAIS", "NOM_PAIS", lINEA_AEREA.COD_PAIS);
            return View(lINEA_AEREA);
        }

        // GET: LineaAerea/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEA_AEREA lINEA_AEREA = db.LINEA_AEREA.Find(id);
            if (lINEA_AEREA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", lINEA_AEREA.COD_AEROPUERTO);
            ViewBag.COD_PAIS = new SelectList(db.PAIS, "COD_PAIS", "NOM_PAIS", lINEA_AEREA.COD_PAIS);
            return View(lINEA_AEREA);
        }

        // POST: LineaAerea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_LINEA_AEREA,COD_AEROPUERTO,NOM_OFICIAL,NOM_CORTO,NOM_REPRESENTANTE,COD_PAIS,URL,FACEBOOK,TWITTER,INSTAGRAM,YOUTUBE,EMAIL,FECHA_FUNDACION,ESTADO_LA")] LINEA_AEREA lINEA_AEREA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lINEA_AEREA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_AEROPUERTO = new SelectList(db.AEROPUERTO, "COD_AEROPUERTO", "NOM_AEROPUERTO", lINEA_AEREA.COD_AEROPUERTO);
            ViewBag.COD_PAIS = new SelectList(db.PAIS, "COD_PAIS", "NOM_PAIS", lINEA_AEREA.COD_PAIS);
            return View(lINEA_AEREA);
        }

        // GET: LineaAerea/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEA_AEREA lINEA_AEREA = db.LINEA_AEREA.Find(id);
            if (lINEA_AEREA == null)
            {
                return HttpNotFound();
            }
            return View(lINEA_AEREA);
        }

        // POST: LineaAerea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LINEA_AEREA lINEA_AEREA = db.LINEA_AEREA.Find(id);
            db.LINEA_AEREA.Remove(lINEA_AEREA);
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
