using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class ReferenciaLN
    {
        #region "PATRON SINGLETON"
        private static ReferenciaLN objReferencia = null;
        private ReferenciaLN() { }
        public static ReferenciaLN getInstance()
        {
            if (objReferencia == null)
            {
                objReferencia = new ReferenciaLN();
            }
            return objReferencia;
        }
        #endregion


        public bool RegistrarReferencia(Referencia objReferencia)
        {
            try
            {
                return ReferenciaDAO.getInstance().RegistrarReferencia(objReferencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Referencia> ListarReferencias()
        {
            try
            {
                return ReferenciaDAO.getInstance().ListarReferencias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Actualizar(Referencia objReferencia)
        {
            try
            {
                return ReferenciaDAO.getInstance().Actualizar(objReferencia);
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
                return ReferenciaDAO.getInstance().Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
