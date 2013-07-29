using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class SessionesController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /Sessiones/

        public ActionResult Index()
        {
            return View(db.sesiones.ToList());
        }

        //
        // GET: /Sessiones/Details/5

        public ActionResult Details(int id = 0)
        {
            sesiones sesiones = db.sesiones.Find(id);
            if (sesiones == null)
            {
                return HttpNotFound();
            }
            return View(sesiones);
        }

        //
        // GET: /Sessiones/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sessiones/Create

        [HttpPost]
        public ActionResult Create(sesiones sesiones)
        {
            if (ModelState.IsValid)
            {
                db.sesiones.Add(sesiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sesiones);
        }

        //
        // GET: /Sessiones/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sesiones sesiones = db.sesiones.Find(id);
            if (sesiones == null)
            {
                return HttpNotFound();
            }
            return View(sesiones);
        }

        //
        // POST: /Sessiones/Edit/5

        [HttpPost]
        public ActionResult Edit(sesiones sesiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sesiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sesiones);
        }

        //
        // GET: /Sessiones/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sesiones sesiones = db.sesiones.Find(id);
            if (sesiones == null)
            {
                return HttpNotFound();
            }
            return View(sesiones);
        }

        //
        // POST: /Sessiones/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            sesiones sesiones = db.sesiones.Find(id);
            db.sesiones.Remove(sesiones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}