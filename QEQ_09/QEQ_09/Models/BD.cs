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

    }
}