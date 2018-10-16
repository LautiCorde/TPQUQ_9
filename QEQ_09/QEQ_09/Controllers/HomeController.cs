using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}