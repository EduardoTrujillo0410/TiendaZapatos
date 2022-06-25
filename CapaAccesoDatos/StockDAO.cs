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

        public List<Stock> ListarStock()
        {
            List<Stock> Lista = new List<Stock>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spListarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Paciente
                    Stock objStock = new Stock();
                    objStock.idStock = Convert.ToInt32(dr["idStock"].ToString());
                    objStock.serial = dr["serial"].ToString();
                    objStock.nomReferencia = dr["nomReferencia"].ToString();

                    // añadir a la lista de objetos
                    Lista.Add(objStock);
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


        public bool Actualizar(Stock objStock)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spActualizarDatosStock", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdStock", objStock.idStock);
                cmd.Parameters.AddWithValue("@prmSerial", objStock.serial);

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
                cmd = new SqlCommand("spEliminarStock", conexion);
                cmd.Parameters.AddWithValue("@prmIdStock", id);
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
