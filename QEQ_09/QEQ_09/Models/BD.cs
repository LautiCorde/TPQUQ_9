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

        public static string connectionString = "Server = LocalHost;Database=WebNews;Trusted_Connection=True;";

        public static void Desconectar(SqlConnection conexion)
        {
            conexion.Close();

        }

        public static bool Login (int idUsuario)
        {

            bool User = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ObtenerUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader dataReader = consulta.ExecuteReader();

            if (dataReader.Read())
            {
                User = true;

            }
            Desconectar(Conexion);
            return User;
        }

    }
}