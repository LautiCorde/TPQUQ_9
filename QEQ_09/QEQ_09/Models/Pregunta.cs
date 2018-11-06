using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ_09.Models
{
    public class Pregunta
    {
        int idPregunta;
        int TipoPregunta;
        int CategoriaPregunta;

        public int IdPregunta { get => idPregunta; set => idPregunta = value; }
        public int TipoPregunta1 { get => TipoPregunta; set => TipoPregunta = value; }
        public int CategoriaPregunta1 { get => CategoriaPregunta; set => CategoriaPregunta = value; }
    }
}