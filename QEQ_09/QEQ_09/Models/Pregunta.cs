using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ_09.Models
{
    public class Pregunta
    {
        int _idPregunta;
        string _Preguntas;
        int _idCategoria;

        public Pregunta(int id, string pre, int idCat)
        {
            _idPregunta = id;
            _Preguntas = pre;
            _idCategoria = idCat;
        }

        public Pregunta() { }

        public int IdPregunta { get => _idPregunta; set => _idPregunta = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Preguntas { get => _Preguntas; set => _Preguntas = value; }

    }
}