using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoporteWeb.Models;

namespace SoporteWeb.Controllers
{
    [Authorize]
    public class CostoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Costoes
        public ActionResult Index()
        {
            var costos = db.Costos.Include(c => c.Tipo);
            return View(costos.ToList());
        }

        // GET: Costoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costo costo = db.Costos.Find(id);
            if (costo == null)
            {
                return HttpNotFound();
            }
            return View(costo);
        }

        // GET: Costoes/Create
        public ActionResult Create()
        {
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Name");
            return View();
        }

        // POST: Costoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,Description,TipoId")] Costo costo)
        {
            if (ModelState.IsValid)
            {
                db.Costos.Add(costo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Name", costo.TipoId);
            return View(costo);
        }

        // GET: Costoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costo costo = db.Costos.Find(id);
            if (costo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Name", costo.TipoId);
            return View(costo);
        }

        // POST: Costoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Description,TipoId")] Costo costo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Name", costo.TipoId);
            return View(costo);
        }

        // GET: Costoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costo costo = db.Costos.Find(id);
            if (costo == null)
            {
                return HttpNotFound();
            }
            return View(costo);
        }

        // POST: Costoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Costo costo = db.Costos.Find(id);
            db.Costos.Remove(costo);
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
