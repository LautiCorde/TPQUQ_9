using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ_09.Models
{
    public class Caracteristicas
    {
        int idCaracteristica;
        int fk_Categoria;
        string Caracteristica;

        public int IdCaracteristica { get => idCaracteristica; set => idCaracteristica = value; }
        public int Fk_Categoria { get => fk_Categoria; set => fk_Categoria = value; }
        public string Caracteristica1 { get => Caracteristica; set => Caracteristica = value; }
    }
}