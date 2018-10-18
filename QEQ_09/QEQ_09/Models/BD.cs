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
        public static SqlConnection Connect()
        {
            //SqlConnection A = new SqlConnection("[DIRECCION DE LA BASE]");
            A.Open();
            return A;
        }

        //PARA DESCONECTARSE: Acces.Close();



    }
}