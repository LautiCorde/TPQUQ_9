﻿using System;
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


        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> aux3 = new List<Usuario>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idUsuario = Convert.ToInt32(dataReader["idUsuario"]);
                string Nombre = Convert.ToString(dataReader["Nombre"]);
                bool Tipo = Convert.ToBoolean(dataReader["Tipo"]);
                string Email = Convert.ToString(dataReader["Email"]);
                string Password = Convert.ToString(dataReader["Password"]);

                Usuario u = new Usuario(idUsuario, Nombre, Tipo, Email, Password);
                aux3.Add(u);

            }


            Desconectar(Conexion);
            return aux3;

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


        private static int InsertarPregunta(Pregunta p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pPregunta", p.Preguntaa);
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
        {
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
            consulta.Parameters.AddWithValue("@pNombre", p.Nombre1);
            consulta.Parameters.AddWithValue("@fk_Categoria", p.Fk_Categoria);
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