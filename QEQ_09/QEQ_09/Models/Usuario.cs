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

        public Usuario(int id, string nom, bool tipo, string email, string pass)
        {
            _idUsuario = id;
            _NomUsuario = nom;
            _TipoUsuario = tipo;
            _Email = email;
            _Password = pass;
        }

        public Usuario()
        {
            _idUsuario = 0;
            _NomUsuario = "";
            _TipoUsuario = 0;
            _Email = "";
            _Password = "";
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NomUsuario { get => _NomUsuario; set => _NomUsuario = value; }
        public bool TipoUsuario { get => _TipoUsuario; set => _TipoUsuario = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Password { get => _Password; set => _Password = value; }




    }
}