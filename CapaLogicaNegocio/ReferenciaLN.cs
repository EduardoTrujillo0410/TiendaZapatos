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
    }

}
