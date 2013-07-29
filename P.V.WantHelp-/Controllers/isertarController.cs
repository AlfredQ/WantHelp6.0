using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Utils;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class isertarController : Controller
    {
        //
        // GET: /isertar/
        PlataformaVirtualEntities db = new PlataformaVirtualEntities();

        public ActionResult crearusuario()
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
        [HttpPost]
        public ActionResult crearusuario(Usuario user)
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
            isertar contexto = new isertar();
            if (contexto.insertarusuario(user)) {
                return View("Index");
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
