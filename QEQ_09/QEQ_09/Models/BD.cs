using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace QEQ_09.Models
{
    public class BD
    {
        private static SqlConnection Conectar()
        {
            SqlConnection a = new SqlConnection(connectionString);
            a.Open();
            return a;
        }

        public static string connectionString = "Server = 10.128.8.16;Database=QEQC09;User ID = QEQC09; Pwd = QEQC09;";

        public static void Desconectar(SqlConnection conexion)
        {
            conexion.Close();

        }

        public static bool  Login (string Email, string Password)
        {
            bool Existencia=false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ObtenerUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Email", Email);
            consulta.Parameters.AddWithValue("@Password", Password);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                Existencia = true; 
            }

            Desconectar(Conexion);
            return Existencia;
        }

        public static bool BackOfficeLogin(string aEmail, string aPassword)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ObtenerUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Email", aEmail);
            consulta.Parameters.AddWithValue("@Password", aPassword);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Usuario u = null;
            if (dataReader.Read())
            {
                int idUsuario = Convert.ToInt32(dataReader["idUsuario"]);
                string NomUsuario = dataReader["NomUsuario"].ToString();
                bool TipoUsuario = Convert.ToBoolean(dataReader["TipoUsuario"]);
                string Email = dataReader["Email"].ToString();
                string Password = dataReader["Passsword"].ToString();

                u = new Usuario(idUsuario, NomUsuario, TipoUsuario, Email, Password);
            }

            bool adm = false;
            if (u.TipoUsuario == true)
            {
                adm = true;
            }

            Desconectar(Conexion);
            return adm;
        }


    }
}