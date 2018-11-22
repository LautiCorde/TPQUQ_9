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

        public Personaje(int id, string nom, int fkcat)
        {
            idPersonaje = id;
            Nombre = nom;
            fk_Categoria = fkcat;
        }
        public Personaje() { }

        [Required(ErrorMessage = "Id inválido.")]
        public int IdPersonaje { get => idPersonaje; set => idPersonaje = value; }
        [Required(ErrorMessage = "Nombre inválido.")]
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        [Required(ErrorMessage = "Categoria inválida.")]
        public int Fk_Categoria { get => fk_Categoria; set => fk_Categoria = value; }
    }
}