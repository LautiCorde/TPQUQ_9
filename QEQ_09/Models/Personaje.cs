using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace QEQ_09.Models
{

  public class Personaje
    {

        int idPersonaje;
        string Nombre;
        int fk_Categoria;
        List<Caracteristicas> caracteristicas;

        public int IdPersonaje { get => idPersonaje; set => idPersonaje = value; }

        [Required(ErrorMessage = "Ingresá un nombre válido")]
        public string Nombre1 { get => Nombre; set => Nombre = value; }

        [Required(ErrorMessage = "Ingresá una categoria valida")]

        public int Fk_Categoria { get => fk_Categoria; set => fk_Categoria = value; }
        public List<Caracteristicas> Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

        public Personaje(int id, string nom, int fkcat, List<Caracteristicas> car)
        {
            Caracteristicas = car;
            idPersonaje = id;
            Nombre = nom;
            fk_Categoria = fkcat;
        }
        public Personaje()
        {
            Caracteristicas = new List<Caracteristicas>();
            IdPersonaje = 0;
            Nombre = "";
            fk_Categoria = 0;
        }

    }

}

