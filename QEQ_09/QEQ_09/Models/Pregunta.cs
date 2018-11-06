using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ_09.Models
{
    public class Pregunta
    {
        int _idPregunta;
        string _Preguntaa;
        int _TipoPregunta;
        int _CategoriaPregunta;

        public int IdPregunta { get => _idPregunta; set => _idPregunta = value; }
        public string Preguntaa { get => _Preguntaa; set => _Preguntaa = value; }
        public int TipoPregunta { get => _TipoPregunta; set => _TipoPregunta = value; }
        public int CategoriaPregunta { get => _CategoriaPregunta; set => _CategoriaPregunta = value; }
    }
}