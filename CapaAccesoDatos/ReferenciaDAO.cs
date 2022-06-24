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

        public List<Referencia> ListarReferencias()
        {
            List<Referencia> Lista = new List<Referencia>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spListarReferencias", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Paciente
                    Referencia objReferencia = new Referencia();
                    objReferencia.idReferencia = Convert.ToInt32(dr["idReferencia"].ToString());
                    objReferencia.NomReferencia = dr["nomReferencia"].ToString();
                    objReferencia.RefSerial = dr["refSerial"].ToString();
                    
                    // añadir a la lista de objetos
                    Lista.Add(objReferencia);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return Lista;
        }


        public bool Actualizar(Referencia objReferencia)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spActualizarDatosReferencia", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdReferencia", objReferencia.idReferencia);
                cmd.Parameters.AddWithValue("@prmRefSerial", objReferencia.RefSerial);

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }


        public bool Eliminar(int id)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spEliminarReferencia", conexion);
                cmd.Parameters.AddWithValue("@prmIdReferencia", id);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }
    }
}
