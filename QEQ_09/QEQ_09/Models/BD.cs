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

        public static List<Personaje> ListarPersonajes()
        {
            List<Personaje> aux3 = new List<Personaje>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idPersonaje = Convert.ToInt32(dataReader["idPersonaje"]);
                string Nombre = Convert.ToString(dataReader["Nombre"]);
                int Fk_Categoria = Convert.ToInt32(dataReader["Fk_Categoria"]);

                Personaje p = new Personaje(idPersonaje,Nombre,Fk_Categoria);
                aux3.Add(p);

            }


            Desconectar(Conexion);
            return aux3;

        }

        public static Personaje ObtenerPersonaje(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ObtenerPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("pId", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Personaje p = new Personaje();
            while (dataReader.Read())
            {
                int idPersonaje = Convert.ToInt32(dataReader["idPersonaje"]);
                string Nombre = Convert.ToString(dataReader["Nombre"]);
                int Fk_Categoria = Convert.ToInt32(dataReader["Fk_Categoria"]);

                p = new Personaje(idPersonaje, Nombre, Fk_Categoria);
            }
            Desconectar(Conexion);
            return p;

        }







        public static List<Pregunta> ListarPreguntas()
        {
            List<Pregunta> aux5 = new List<Pregunta>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idPregunta = Convert.ToInt32(dataReader["idPregunta"]);
                string Pregunta = Convert.ToString(dataReader["Pregunta"]);
                int idCat = Convert.ToInt32(dataReader["idCat"]);
                Pregunta p = new Pregunta (idPregunta, Pregunta, idCat);
                aux5.Add(p);

            }


            Desconectar(Conexion);
            return aux5;

        }




        public static Pregunta ObtenerPregunta(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ObtenerPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("pidPreg", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Pregunta p = null;
            while (dataReader.Read())
            {
                int idPregunta = Convert.ToInt32(dataReader["idPregunta"]);
                string Preguntas = Convert.ToString(dataReader["Preguntas"]);
                int idCat = Convert.ToInt32(dataReader["idCat"]);
                p = new Pregunta(idPregunta, Preguntas);
            }
            Desconectar(Conexion);
            return p;

        }



        public static bool Login(string Email, string Password)
        {
            bool Existencia = false;
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


       public static int InsertarPregunta(Pregunta p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pPregunta", p.Preguntas);
            consulta.Parameters.AddWithValue("@idCategoria", p.idCategoria);
            int NuevaPreg = consulta.ExecuteNonQuery();
            return NuevaPreg;
        }
        
        public static int ModifcarPregunta(int Id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pid", Id);
            int PreguntaModificada = consulta.ExecuteNonQuery();
            return PreguntaModificada;
        }
        public static bool BorrarPregunta(int Id)
        {
            bool Preguntaa = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EliminarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", Id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                Preguntaa = true;
            }
            Desconectar(Conexion);
            return Preguntaa;
        }
        public static int InsertarPersonaje(Personaje p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombre", p.Nombre1);
            consulta.Parameters.AddWithValue("@Caracteristica", p.Fk_Categoria);
            int NuevoPersonaje = consulta.ExecuteNonQuery();
            return NuevoPersonaje;
        }
        public static int ModifcarPersonaje(Personaje x)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pid", x.IdPersonaje);
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre1);
            consulta.Parameters.AddWithValue("@pCategoria", x.Fk_Categoria);
            int PersonajeModificado = consulta.ExecuteNonQuery();
            return PersonajeModificado;
        }
        public static bool BorrarPersonaje(int Id)
        {
            bool Personaje = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EliminarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pid", Id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                Personaje = true;
            }
            Desconectar(Conexion);
            return Personaje;
        }

        /*public static List<CategoriaPersonaje> ListarCategoriaPersonaje()
        {
            List<CatergoriaPersonaje> aux3 = new List<CategoriaPersonaje>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idCatPer = Convert.ToInt32(dataReader["idCatPer"]);
                string CatPer = Convert.ToString(dataReader["CatPer"]);


                Personaje p = new Personaje(idCatPer, CatPer);
                aux3.Add(p);

            }
           

            Desconectar(Conexion);
            return aux3;

        }
         */

      /*  private static int InsertarCatPersonaje(CategoriaPersonaje c)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@CatPer", c.CatPer);
            int NuevaCategoria = consulta.ExecuteNonQuery();
            return NuevaCategoria;
        }

    */
       

        private static int ModifcarCatPersonaje(int idCatPer)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pidCatPer", idCatPer);
            int CategoriaModificada = consulta.ExecuteNonQuery();
            return CategoriaModificada;

        }
    }
}