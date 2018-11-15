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
        public ActionResult AnadirPersonaje(string Nombre, int fkCategoria)
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
                Personaje p= BD.ObtenerPersonaje(id);
                return View("EditarPregunta", p);
            }
            else if (Accion == "Eliminar")
            {
                BD.BorrarPregunta(id);
                return RedirectToAction("AdminPregunta");
            }
            return View();
        }

        [HttpPost]
        public ActionResult GuardarPregunta(Pregunta p)
        {
            BD.ModifcarPregunta(p.IdPregunta);
            return RedirectToAction("AdminPregunta");
        }

        [HttpPost]
        public ActionResult AnadirPregunta(int idPregunta, string Preguntas)
        {
            BD.InsertarPregunta(new Pregunta(-1, Preguntas));
            return RedirectToAction("AdminPreguntas");
        }
    }
}