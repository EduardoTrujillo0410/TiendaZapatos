using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private Conexion()
        {

        }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();   // Se pone el @ para permitir pasar el nombre del servidor y la instancia
            conexion.ConnectionString = @"Data Source=LAPTOP-7JSP6FE5\SQLEXPRESS; Initial Catalog=DBZapatos; User ID=sa; Password=4oct2001";
            return conexion;
        }
    }
}
