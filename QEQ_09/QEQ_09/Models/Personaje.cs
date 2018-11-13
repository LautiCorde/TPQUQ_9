using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ_09.Models
{
    public class Personaje
    {
        int idPersonaje;
        string Nombre;
        int fk_Categoria;

        public Personaje(int id, string nom, int fkcat)
        {
            idPersonaje = id;
            Nombre = nom;
            fk_Categoria = fkcat;
        }

        public int IdPersonaje { get => idPersonaje; set => idPersonaje = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public int Fk_Categoria { get => fk_Categoria; set => fk_Categoria = value; }
    }
}