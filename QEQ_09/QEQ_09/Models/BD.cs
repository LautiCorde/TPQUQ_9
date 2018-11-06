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

        private static int InsertarPregunta(Pregunta p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pPregunta", p.Pregunta);
            int NuevaPreg = consulta.ExecuteNonQuery();
            return NuevaPreg;
        }
        private static int ModifcarPregunta(int Id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pid", Id);
            int PreguntaModificada = consulta.ExecuteNonQuery();
            return PreguntaModificada;
        }
        private static bool BorrarPregunta(int Id)
        {//
            bool Preguntaa = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EliminarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                Preguntaa = true;
            }
            Desconectar(Conexion);
            return Preguntaa;
        }
        private static int InsertarPersonaje(Personaje p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombre", p.Nombre);
            consulta.Parameters.AddWithValue("@Caracteristica", p.Caracteristica);
            int NuevoPersonaje = consulta.ExecuteNonQuery();
            return NuevoPersonaje;
        }
        private static int ModifcarPersonaje(int Id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pid", Id);
            int PersonajeModificado = consulta.ExecuteNonQuery();
            return PersonajeModificado;
        }
        private static bool BorrarPersonaje(int Id)
        {
            bool Personaje = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EliminarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                Personaje = true;
            }
            Desconectar(Conexion);
            return Personaje;
        }


    }
}