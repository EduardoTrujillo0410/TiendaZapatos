using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class StockLN
    {
        #region "PATRON SINGLETON"
        private static StockLN objStock = null;
        private StockLN() { }
        public static StockLN getInstance()
        {
            if (objStock == null)
            {
                objStock = new StockLN();
            }
            return objStock;
        }
        #endregion


        public bool RegistrarStock(Stock objStock)
        {
            try
            {
                return StockDAO.getInstance().RegistrarStock(objStock);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Stock> ListarStock()
        {
            try
            {
                return StockDAO.getInstance().ListarStock();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Actualizar(Stock objStock)
        {
            try
            {
                return StockDAO.getInstance().Actualizar(objStock);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return StockDAO.getInstance().Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
