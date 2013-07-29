using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P.V.WantHelp_.Utils;
using System.IO;
using P.V.WantHelp_.Models;

namespace P.V.WantHelp_.Controllers
{
    public class CursosController : Controller
    {
        private contextodb db = new contextodb();

        //
        // GET: /Cursos/

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
            return View(db.Cursos.ToList());
        }

        //
        // GET: /Cursos/Details/5

        public ActionResult Details(int id = 0)
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
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // GET: /Cursos/Create

        public ActionResult Create()
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

        //
        // POST: /Cursos/Create

        [HttpPost]
        public ActionResult Create(Cursos cursos, HttpPostedFileBase imagenportada)
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
                db.Entry(cursos).State = EntityState.Modified;
                if (imagenportada != null)
                {
                    var data = new byte[imagenportada.ContentLength];
                    imagenportada.InputStream.Read(data, 0, imagenportada.ContentLength);
                    var path = ControllerContext.HttpContext.Server.MapPath("../PortadasCursos/");
                    //var filemane = Path.Combine(path, Path.GetFileName(imagen.FileName));
                    var filename2 = Path.GetFileName(imagenportada.FileName);
                    string ruta = Server.MapPath("../PortadasCursos/" + filename2);
                    imagenportada.SaveAs(path + filename2);
                    cursos.FotoPortada = "../PortadasCursos/" + imagenportada.FileName;
                }
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cursos);
        }/*
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Cursos Cursos, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image=!null)
                {
                    
                }
                AdminActions contexto= new AdminActions();
                Cursos curso = new Cursos();
                var data1 new byte[urlBase.ContentLength];
                urlBase.InputStream.Read(data1,0,urlBase.ContentLength);
                var path1=ControllerContext.HttpContext.Server.MapPath("/Content/Libros");
                var filename1 = Path.Combine(path1, Path.GetFileName(contenido.FileName));
                System.IO.File.WriteAllBytes(Path.Combine(path1, filename1), data1);
                curso.urlBase= (urlBase.FileName).ToString();
                
                curso.urlBase= 
            }
        }*/
        //
        // GET: /Cursos/Edit/5

        public ActionResult Edit(int id = 0)
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
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // POST: /Cursos/Edit/5

        [HttpPost]
        public ActionResult Edit(Cursos cursos)
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
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cursos);
        }

        //
        // GET: /Cursos/Delete/5

        public ActionResult Delete(int id = 0)
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
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        //
        // POST: /Cursos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
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
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        /* chat*/
        [HttpPost]
        public JsonResult Enviar(mensajes msn1)
        {
            if (Session["idUs"] == null)
            {
                return Json(new { data = false });
            }
            msn1.idUs = Convert.ToInt32(Session["idUsuario"]);
            msn1.fecha = DateTime.Now;
            msn1.idSe = msn1.idSe;
            msn1.estado = 0;
            AdminActions contexto = new AdminActions();
            if (contexto.EnviarMensaje(msn1))
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }
        [HttpPost]
        public JsonResult getMensajes(mensajes msn)
        {
            MensajeActions contexto = new MensajeActions();
            List<mensajes> ListaMensajes = contexto.getMensajes(msn.idSe);
            List<MensajesView> listaMostrar = new List<MensajesView>();
            foreach (var item in ListaMensajes)
            {
                MensajesView ins = new MensajesView()
                {
                    nick = item.Usuario.Nombre,
                    mmensaje = item.mensaje,
                    fecha = item.fecha.ToString()
                };
                listaMostrar.Add(ins);
            }
            return Json(new { lista = listaMostrar });
        }
        public JsonResult getUsuarios()
        {
            AdminActions contexto = new AdminActions();
            List<Usuario> lista = contexto.getUsuarioConectado();
            List<string> nicks = new List<string>();
            foreach (var item in lista)
            {
                nicks.Add(item.Nombre);
            }
            return Json(new { lista = nicks });
        }
        public JsonResult getCursos()
        {
            AdminActions contexto = new AdminActions();
            List<Cursos> ListCurso = contexto.getCurso();
            List<string> course = new List<string>();
            foreach (var item in ListCurso)
            {
                course.Add(item.Titulo);
            }
            return Json(new { lista = course });
        }
        [HttpPost]
        public JsonResult EnviarBlog(Respuestas_Chat msjrc)
        {
            if (Session["idUs"] == null)
            {
                return Json(new { data = false });
            }
            msjrc.idSe=msjrc.idSe;
            msjrc.idUs=Convert.ToInt32(Session["idUsuario"]);
            msjrc.fecha= DateTime.Now;
            msjrc.idChat = 1;
            AdminActions contexto = new AdminActions();
            if (contexto.EnviarMensajeR(msjrc))
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }
        [HttpPost]
        public JsonResult getMensajesR(Respuestas_Chat msjrc)
        { 
            MensajeActions contexto = new MensajeActions();
            List<Respuestas_Chat> listaMensajeR = contexto.getMensajesR(msjrc.idSe);
            List<MensajesViewR> listraMostrarR = new List<MensajesViewR>();
            foreach (var item in listaMensajeR)
            {
                MensajesViewR insr= new MensajesViewR(){

                    nickR=item.Usuario.Nombre,
                    mensajeR= item.mensaje,
                    fechaR = item.fecha.ToString()
                };
                listraMostrarR.Add(insr);
            }
            return Json(new { lista = listraMostrarR });
        }
    }
}