using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Models;
using P.V.WantHelp_.Utils;
using WebMatrix.WebData;

namespace P.V.WantHelp_.Controllers
{
    public class HomeController : Controller
    {
        PlataformaVirtualEntities db = new PlataformaVirtualEntities();
        public ActionResult Index()
        {
            
            List<Listacurso> lista = db.Cursos.Select(a => new Listacurso()
            {
                id = a.Id_Curso,
                titulo = a.Titulo,
                descripcion = a.Descripcion,
                portadascurso=a.FotoPortada
            }).Take(6).OrderByDescending(a => a.id).ToList();
            ViewBag.lista = lista;
            List<Listacurso> lista2 = db.Cursos.Select(a => new Listacurso()
            {
                id = a.Id_Curso,
                titulo = a.Titulo
            }).OrderByDescending(a => a.id).ToList();
            ViewBag.lista2=lista2;
            if (Request.IsAuthenticated)
            {
                /*  foto Avatar  */
                //int aux = Convert.ToInt32(Session["idUsuario"]);
                //string Cadenausuario = db.Usuario.Where(a => a.Id_Usu == aux).FirstOrDefault().Avatar;
                //ViewBag.fotoA = Cadenausuario;
                /*******************/
                Permisos check = new Permisos(Convert.ToInt32(Session["idus"]));
                ViewBag.Menus = check.getPermisos();
            };
            
            ViewBag.Message = "Cursos con Certificado de Profesionalidad";

            return View();
        }
        public ActionResult modificado()
        {
            ViewBag.Message = "Modify this MVC application.";

            return View();
        }

        public ActionResult modificado2()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
		public ActionResult MiCurso()
		{
			ViewBag.Message = "los cursos que se dan";

            return View();
		}
        public ActionResult About()
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
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
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
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Contacto()
        {
            ViewBag.Message = "Informaciones de nuestros cursos";
            return View();
        }
       
    }
}
