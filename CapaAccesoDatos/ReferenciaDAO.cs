using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ReferenciaDAO
    {
        #region "PATRON SINGLETON"
        private static ReferenciaDAO daoReferencia = null;
        private ReferenciaDAO() { }
        public static ReferenciaDAO getInstance()
        {
            if (daoReferencia == null)
            {
                daoReferencia = new ReferenciaDAO();
            }
            return daoReferencia;
        }
        #endregion

        public bool RegistrarReferencia(Referencia objReferencia)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spRegistrarReferencia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNomReferencia", objReferencia.NomReferencia);
                cmd.Parameters.AddWithValue("@prmRefSerial", objReferencia.RefSerial);
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
