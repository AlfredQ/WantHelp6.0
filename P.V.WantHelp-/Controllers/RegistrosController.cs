using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Utils;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class RegistrosController : Controller
    {
        PlataformaVirtualEntities db = new PlataformaVirtualEntities();
        //
        // GET: /Registros/
        public ActionResult RegistroCurso() {
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
            return View();
        }
        [HttpPost]
        public ActionResult RegistroCurso(Cursos rcurso)
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
            if (ModelState.IsValid)
            {
                PlataformaVirtualEntities conex = new PlataformaVirtualEntities();
                try {
                    Cursos c = new Cursos();
                    c.Titulo = rcurso.Titulo;
                    c.Descripcion = rcurso.Descripcion;
                    c.Fecha_I = rcurso.Fecha_I;
                    c.Fecha_F = rcurso.Fecha_F;
                    c.urlBase = rcurso.urlBase;
                    c.urlHost = rcurso.urlHost;

                    conex.Cursos.Add(c);
                    conex.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                catch { 
                
                }
            }
            return View();
        }
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
            return View();
        }

    }
}
