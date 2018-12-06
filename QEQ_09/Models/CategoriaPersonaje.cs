using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ_09.Models
{
    public class CategoriaPersonaje
    {
        int idCatPer;
        string CatPer;

        public CategoriaPersonaje() { }

        public CategoriaPersonaje(int id, string catp)
        {
            IdCatPer = id;
          CatPer= catp;
          
        }


        public int IdCatPer { get => idCatPer; set => idCatPer = value; }
        [Required(ErrorMessage = "Ingresá un nombre válido")]
        public string CatPer1 { get => CatPer; set => CatPer = value; }
    }
}