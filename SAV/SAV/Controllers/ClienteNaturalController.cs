using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAV.Models;
using System.Security.Claims;

namespace SAV.Controllers
{
    public class ClienteNaturalController : Controller
    {
        private SAVEntities db = new SAVEntities();

        // GET: ClienteNatural
        [Authorize]
        public ActionResult Index()
        {
            User.Identity.ToString() ;
            var cLIENTE_NATURAL = db.CLIENTE_NATURAL.Include(c => c.Persona).Include(c => c.GENERO).Include(c => c.TIPO_DOCUMENTO);
            return View(cLIENTE_NATURAL.ToList());
        }

        // GET: ClienteNatural/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {

           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE_NATURAL cLIENTE_NATURAL = db.CLIENTE_NATURAL.Find(id);
            if (cLIENTE_NATURAL == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE_NATURAL);
        }
        [Authorize]
        // GET: ClienteNatural/Create
        public ActionResult Create()
        {
            ViewBag.ID_Persona = new SelectList(db.Persona, "ID_Persona", "PRIMER_NOM");
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOM_GENERO");
            ViewBag.ID_TIPO_DOCUMENTO = new SelectList(db.TIPO_DOCUMENTO, "ID_TIPO_DOCUMENTO", "NOM_DOCUMENTO");
            return View();
        }

        // POST: ClienteNatural/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NATURAL,ID_Persona,ID_TIPO_DOCUMENTO,NUM_DOCUMETO,FECHA_NACIMIENTO,ID_GENERO,ESTADO_CIVIL,NUM_MILLAS,NUM_VIAJERO_FREC")] CLIENTE_NATURAL cLIENTE_NATURAL)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE_NATURAL.Add(cLIENTE_NATURAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Persona = new SelectList(db.Persona, "ID_Persona", "PRIMER_NOM", cLIENTE_NATURAL.ID_Persona);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOM_GENERO", cLIENTE_NATURAL.ID_GENERO);
            ViewBag.ID_TIPO_DOCUMENTO = new SelectList(db.TIPO_DOCUMENTO, "ID_TIPO_DOCUMENTO", "NOM_DOCUMENTO", cLIENTE_NATURAL.ID_TIPO_DOCUMENTO);
            return View(cLIENTE_NATURAL);
        }

        // GET: ClienteNatural/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE_NATURAL cLIENTE_NATURAL = db.CLIENTE_NATURAL.Find(id);
            if (cLIENTE_NATURAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Persona = new SelectList(db.Persona, "ID_Persona", "PRIMER_NOM", cLIENTE_NATURAL.ID_Persona);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOM_GENERO", cLIENTE_NATURAL.ID_GENERO);
            ViewBag.ID_TIPO_DOCUMENTO = new SelectList(db.TIPO_DOCUMENTO, "ID_TIPO_DOCUMENTO", "NOM_DOCUMENTO", cLIENTE_NATURAL.ID_TIPO_DOCUMENTO);
            return View(cLIENTE_NATURAL);
        }

        // POST: ClienteNatural/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NATURAL,ID_Persona,ID_TIPO_DOCUMENTO,NUM_DOCUMETO,FECHA_NACIMIENTO,ID_GENERO,ESTADO_CIVIL,NUM_MILLAS,NUM_VIAJERO_FREC")] CLIENTE_NATURAL cLIENTE_NATURAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE_NATURAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Persona = new SelectList(db.Persona, "ID_Persona", "PRIMER_NOM", cLIENTE_NATURAL.ID_Persona);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOM_GENERO", cLIENTE_NATURAL.ID_GENERO);
            ViewBag.ID_TIPO_DOCUMENTO = new SelectList(db.TIPO_DOCUMENTO, "ID_TIPO_DOCUMENTO", "NOM_DOCUMENTO", cLIENTE_NATURAL.ID_TIPO_DOCUMENTO);
            return View(cLIENTE_NATURAL);
        }

        // GET: ClienteNatural/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE_NATURAL cLIENTE_NATURAL = db.CLIENTE_NATURAL.Find(id);
            if (cLIENTE_NATURAL == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE_NATURAL);
        }

        // POST: ClienteNatural/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE_NATURAL cLIENTE_NATURAL = db.CLIENTE_NATURAL.Find(id);
            db.CLIENTE_NATURAL.Remove(cLIENTE_NATURAL);
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
