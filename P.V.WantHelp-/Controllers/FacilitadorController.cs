using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using P.V.WantHelp_.Utils;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class FacilitadorController : Controller
    {
        //
        // GET: /Facilitador/
        private contextodb db = new contextodb();
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                /*  foto Avatar  */
                int aux = Convert.ToInt32(Session["idUsuario"]);
                string Cadenausuario = db.Usuario.Where(a => a.Id_Usu == aux).FirstOrDefault().Avatar;
                ViewBag.fotoA = Cadenausuario;
                /*******************/
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            return View(db.Cursos.OrderByDescending(a => a.Id_Curso).ToList());
        }
        public ActionResult ClasesCurso(int id)
        {
            ViewBag.idUs = Session["idUsuario"];
            ViewBag.idSesion = id;
            ViewBag.idCu = id;
            if (Request.IsAuthenticated)
            {
                /*  foto Avatar  */
                int aux = Convert.ToInt32(Session["idUsuario"]);
                string Cadenausuario = db.Usuario.Where(a => a.Id_Usu == aux).FirstOrDefault().Avatar;
                ViewBag.fotoA = Cadenausuario;
                /*******************/
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            CursosActions contextoC = new CursosActions();
            return View(contextoC.getSesiones(id));
        }
        public ActionResult Create()
        {
            //ViewBag.idCu = id;
            return View();
        }
        public ActionResult CrearClass(int id)
        {
            ViewBag.idCu = id;
            return View();
        }
        //
        // POST: /Sessiones/Create
        [HttpPost]
        public ActionResult CrearClass(sesiones sesiones)
        {
            if (ModelState.IsValid)
            {
                sesiones sc = new Models.sesiones();
                sc.titulo = sesiones.titulo;
                sc.descriocion = sesiones.descriocion;
                sc.idCu = 5;
                db.sesiones.Add(sc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            /*if (ModelState.IsValid)
            {
                db.sesiones.Add(sesiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return View(sesiones);
        }
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

    }
}
