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

        public static bool  Login (int IdUsuario)
        {
            bool A = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "GetUser";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pidUsuario", IdUsuario);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                A = true; 
            }
            Desconectar(Conexion);
            return A;
        }

    }
}