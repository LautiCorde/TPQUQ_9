using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ_09.Models
{
    public class Usuario
    {
        private int _idUsuario;
        private string _NomUsuario;
        private bool _TipoUsuario;
        private string _Email;
        private string _Password;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NomUsuario { get => _NomUsuario; set => _NomUsuario = value; }
        public bool TipoUsuario { get => _TipoUsuario; set => _TipoUsuario = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Password { get => _Password; set => _Password = value; }


    }
}