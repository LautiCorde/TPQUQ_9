using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ_09.Models
{
    public class Pregunta
    {
        int _idPregunta;
        string _Preguntas;
        int _idCategoria;

        public Pregunta(int id, string pre, int idCa)
        {
            _idPregunta = id;
            _Preguntas = pre;
            _idCategoria = idCa;
        }

        public Pregunta() { }

        public int IdPregunta { get => _idPregunta; set => _idPregunta = value; }
        [Required(ErrorMessage = "Ingresá una categoria valida")]
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        [Required(ErrorMessage = "Ingresá una categoria valida")]
        public string Preguntas { get => _Preguntas; set => _Preguntas = value; }

    }
}