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

        public Pregunta(int id, string pre)
        {
            _idPregunta = id;
             _Preguntas= pre;
            
        }

        public int IdPregunta { get => _idPregunta; set => _idPregunta = value; }
        public string Preguntas { get => _Preguntas; set => _Preguntas = value; }
   
    }
}