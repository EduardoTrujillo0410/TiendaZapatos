using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class StockDAO
    {
        #region "PATRON SINGLETON"
        private static StockDAO daoStock = null;
        private StockDAO() { }
        public static StockDAO getInstance()
        {
            if (daoStock == null)
            {
                daoStock = new StockDAO();
            }
            return daoStock;
        }
        #endregion

        public bool RegistrarStock(Stock objStock)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spRegistrarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmSerial", objStock.serial);
                cmd.Parameters.AddWithValue("@prmNomReferencia", objStock.nomReferencia);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }
    }
}
