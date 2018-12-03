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

        public static void InsertarCaracteristicaxPersonaje(int IdCaracteristica, int IdPersonaje)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "InsertarCaracteristicaxPersonaje";
            consulta.Parameters.AddWithValue("@idcaracteristica", IdCaracteristica);
            consulta.Parameters.AddWithValue("@idpersonaje", IdPersonaje);
            consulta.ExecuteNonQuery();
            Desconectar(Conexion);
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
            consulta.CommandText = "ListarPreguntas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idPregunta = Convert.ToInt32(dataReader["idPregunta"]);
                string Pregunta = Convert.ToString(dataReader["Pregunta"]);
                int idCategoria = Convert.ToInt32(dataReader["idCategoria"]);
                Pregunta p = new Pregunta(idPregunta, Pregunta, idCategoria);
                aux5.Add(p);

            }


            Desconectar(Conexion);
            return aux5;

        }

        public static List<Caracteristicas> ListarCaracteristicas()
        {
            List<Caracteristicas> aux6 = new List<Caracteristicas>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarCaracteristicas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idCaracteristica = Convert.ToInt32(dataReader["idcaracteristica"]);
                string Caracteristica = Convert.ToString(dataReader["Caracteristica"]);
                int fkCategoria = Convert.ToInt32(dataReader["fk_Categoria"]);
                Caracteristicas c = new Caracteristicas(idCaracteristica, Caracteristica, fkCategoria);
                aux6.Add(c);

            }



            Desconectar(Conexion);
            return aux6;

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
                string Preguntas = Convert.ToString(dataReader["Pregunta"]);
                int idCategoria = Convert.ToInt32(dataReader["idCategoria"]);
                p = new Pregunta(idPregunta, Preguntas,idCategoria);
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

        public static void InsertarPregunta(Pregunta p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "InsertarPregunta";
            consulta.Parameters.AddWithValue("@pPreg", p.Preguntas);
            consulta.Parameters.AddWithValue("@idCat", p.IdCategoria);
            consulta.ExecuteNonQuery();
            Desconectar(Conexion);
        }


        public static void ModifcarPregunta(Pregunta p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idPregunta", p.IdPregunta);
            consulta.Parameters.AddWithValue("@Pregunta", p.Preguntas);
            consulta.Parameters.AddWithValue("@Tipo", p.IdCategoria);
            consulta.ExecuteNonQuery();
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

        public static void InsertarPersonaje(Personaje p)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "InsertarPersonaje";
            consulta.Parameters.AddWithValue("@pNombre", p.Nombre1);
            consulta.Parameters.AddWithValue("@Fk_Categoria", p.Fk_Categoria);
            consulta.ExecuteNonQuery();
            Desconectar(Conexion);
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

        public static List<CategoriaPersonaje> ListarCategoriaPersonaje()
        {
            List<CategoriaPersonaje> aux3 = new List<CategoriaPersonaje>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idCatPer = Convert.ToInt32(dataReader["idCatPer"]);
                string CatPer = Convert.ToString(dataReader["CatPer"]);


               CategoriaPersonaje cp = new CategoriaPersonaje(idCatPer, CatPer);
                aux3.Add(cp);

            }
           

            Desconectar(Conexion);
            return aux3;

        }

        public static int InsertarCatPersonaje(CategoriaPersonaje cp)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "InsertarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@CatPer", cp.CatPer1);
            int NuevaCategoria = consulta.ExecuteNonQuery();
            return NuevaCategoria;
        }





        public static int ModifcarCatPersonaje(int idCatPer, string CatPer1)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ModificarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pidCatPer", idCatPer);
            consulta.Parameters.AddWithValue("@pCatPer", CatPer1);
            int CategoriaModificada = consulta.ExecuteNonQuery();
            return CategoriaModificada;

        }

        public static CategoriaPersonaje ObtenerCatPer(int idCatPer)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ObtenerCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pidCatPer", idCatPer);
            SqlDataReader dataReader = consulta.ExecuteReader();
            CategoriaPersonaje cp = null;
            while (dataReader.Read())
            {
                
                string CatPer = Convert.ToString(dataReader["CatPer"]);
                cp = new CategoriaPersonaje(idCatPer, CatPer);
            }
            Desconectar(Conexion);
            return cp;

        }


        public static bool BorrarCatPer(int idCatPer)
        {
            bool CatPer = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarCategoriaPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pid", idCatPer);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                CatPer = true;
            }
            Desconectar(Conexion);
            return CatPer;
        }


        public static bool InsertarUsuario(string Mail, string Password, string NomUsuario, bool  Tipo)
        {
            bool b = false;
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "InsertarUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@email", Mail);
            Consulta.Parameters.AddWithValue("@Pass", Password);
            Consulta.Parameters.AddWithValue("@nom", NomUsuario);
            Consulta.Parameters.AddWithValue("@Tipo", Tipo);
            int regsAfec = Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
            if (regsAfec == 1)
            {
                b = true;
            }
            return b;
        }

    }
}