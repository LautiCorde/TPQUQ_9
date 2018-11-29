using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ_09.Models;

namespace QEQ_09.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message  = "Bienvenidos al juego";
            return View();
        }

        public ActionResult InsertarPregunta()
        {
           return View();
        }

        public ActionResult Aboutus()
        {
            ViewBag.Message = "Este juego fue hecho, diseñado y administrado(?) por Lauti Cordero, Juli Demaria y Mateo Laniado en [Octubre - Noviembre 2018] en las materias de Programación y Bases de Datos en el secundario Ort Almagro Argentina.";

            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Instrucciones()
        {
            ViewBag.Message = " Usted debe adivinar el personaje seleccionado por el programa haciendo preguntas respecto a las apariencias de los personajes que se muestran en la pantalla y descartando los adecuados. puede arriesgar en cualquier momento de la partida si cree saber cuál es el personaje.";
            return View();
        }

        public ActionResult OlvidarContraseña()
        {
            ViewBag.Message = "Si usted olvidó su contraseña, siga las instrucciones para recuperar el acceso a su cuenta";
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminUsuario()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AcceptLogin(string Email, string Password)
        {
            if (Email == "" || Password == "")
            {
                ViewBag.MensajeError = "Porfavor llene todos los campos";
                return View("Login");
            }
            else
            {
                bool Existencia;
                Existencia = Models.BD.Login(Email, Password);
                if (Existencia == true)
                {
                    ViewBag.Usuario = "Bienvenido ";
                    return View("Index");
                }
                else
                {
                    ViewBag.MensajeError = "Error. Porfavor intente denuevo.";
                    return View("Login");
                }
            }
        }

        public ActionResult AcceptBackOfficeLogin(string Email, string Password)
        {
            if (Email == "" || Password == "")
            {
                ViewBag.MensajeError = "Porfavor llene todos los campos";
                return View("Login");
            }
            else
            {
                bool adm;
                adm = Models.BD.Login(Email, Password);
                if (adm == true)
                {
                    ViewBag.Usuario = "Bienvenido ";
                    return View("adm");
                }
                else
                {
                    ViewBag.MensajeError = "Error. Usted no es Administrador.";
                    return View("Login");
                }
            }
        }

        [HttpGet]
        public ActionResult BackOfficeLogin()
        {
            return View();
        }

        public ActionResult AdminPersonajes()
        {
            ViewBag.Personaje = BD.ListarPersonajes();
            return View();
        }

        public ActionResult AdministrarPreguntas()
        {
            ViewBag.Pregunta = BD.ListarPreguntas();
            return View();
        }

        public ActionResult EditarPersonaje()
        {
            return View();
        }

        public ActionResult InsertarPersonaje()
        {
            return View();
        }

        public ActionResult AMPersonaje(string Accion, int id)
        {
            if (Accion == "Agregar")
            {
                return RedirectToAction("InsertarPersonaje");
            }
            else if (Accion == "Modificar")
            {
                Personaje x = BD.ObtenerPersonaje(id);
                return View("EditarPersonaje",x);
            }
            else if (Accion == "Eliminar")
            {
                BD.BorrarPersonaje(id);
                return RedirectToAction("AdminPersonajes");
            }
            return View();
        }

        [HttpPost]
        public ActionResult GuardarPersonaje(Personaje x)
        {
            BD.ModifcarPersonaje(x);
            return RedirectToAction("AdminPersonajes");
        }

        [HttpPost]
        public ActionResult AnadirPersonaje(string Nombre, int fkCategoria = 0)
        {
                BD.InsertarPersonaje(new Personaje(-1, Nombre, fkCategoria));
                return RedirectToAction("AdminPersonajes");
            }
            
        

        

        public ActionResult AMPregunta(string Accion, int id)
        {
            if (Accion == "Agregar")
            {
                return RedirectToAction("InsertarPregunta");
            }
            else if (Accion == "Modificar")
            {
                Pregunta p= BD.ObtenerPregunta(id);
                return View("EditarPregunta", p);
            }
            else if (Accion == "Eliminar")
            {
                BD.BorrarPregunta(id);
                return RedirectToAction("AdministrarPreguntas");
            }
            return View();
        }

    
          

        [HttpPost]
        public ActionResult GuardarPregunta(Pregunta p)
        {

            BD.ModifcarPregunta(p);
            return RedirectToAction("AdministrarPreguntas");
        }
        
        [HttpPost]
        public ActionResult InsertarPregunta(string Preguntas, int idCategoria)
        {
            if (Preguntas == "" || idCategoria == 0)
            {
                ViewBag.MensajeError = "Porfavor llene todos los campos";
                return View("InsertarPersonaje");
            }
            else
            {
                BD.InsertarPregunta(new Pregunta(-1, Preguntas, idCategoria));
                return RedirectToAction("AdministrarPreguntas");
            }
                
        }

        [HttpPost]
        public ActionResult Registrarse(string Mail, string Password, string NomUsuario, int Tipo)
        {
            BD.InsertarUsuario(Mail, Password,  NomUsuario, Convert.ToBoolean(Tipo));
            return View("Index");
        }

        public ActionResult AdminCatPer()
        {
            ViewBag.CategoriaPersonaje = BD.ListarCategoriaPersonaje();
            return View();
        }

        public ActionResult EditarCatPer()
        {
            return View();
        }

        public ActionResult InsertarCatPer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarCatPer(CategoriaPersonaje cp)
        {
        
            if (cp.CatPer1 == "")
            {
                ViewBag.MensajeError = "Porfavor llene todos los campos";
                return View("InsertarCatPer");
            }
            else
            {
                // BD.InsertarCatPersonaje(new CategoriaPersonaje(-1, CatPer));
                BD.InsertarCatPersonaje(cp);
                return RedirectToAction("AdminCatPer");
            }

        }

        public  ActionResult GuardarCatPer(CategoriaPersonaje cp, int Id)
        {
            BD.ModifcarCatPersonaje(Id, cp.CatPer1);
            return RedirectToAction("AdminCatPer");
        }

        public ActionResult AMCatPer(string Accion, int id)
        {
            if (Accion == "Agregar")
            {
                return RedirectToAction("InsertarCatPer");
            }
            else if (Accion == "Modificar")
            {
                CategoriaPersonaje cp = BD.ObtenerCatPer(id);
               ViewBag.ID = id;
             
                return View("EditarCatPer", cp);
            }
            else if (Accion == "Eliminar")
            {
                BD.BorrarCatPer(id);
                return RedirectToAction("AdminCatPer");
            }
            return View();
        }
    }
}