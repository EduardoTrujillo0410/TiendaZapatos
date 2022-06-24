using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;


namespace TiendaZapatos
{
    public partial class GestionarReferencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        [WebMethod]
        public static List<Referencia> ListarReferencias()
        {
            List<Referencia> Lista = null;
            try
            {
                Lista = ReferenciaLN.getInstance().ListarReferencias();
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }


        [WebMethod]
        public static bool ActualizarDatosReferencia(String id, String serial)
        {
            Referencia objReferencia = new Referencia()
            {
                idReferencia = Convert.ToInt32(id),
                RefSerial = serial
            };

            bool ok = ReferenciaLN.getInstance().Actualizar(objReferencia);
            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosReferencia(String id)
        {
            Int32 idReferencia = Convert.ToInt32(id);

            bool ok = ReferenciaLN.getInstance().Eliminar(idReferencia);

            return ok;

        }

        private Referencia GetEntity()
        {
            Referencia objReferencia = new Referencia();
            objReferencia.idReferencia = 0;
            objReferencia.NomReferencia = txtReferencia.Text;
            objReferencia.RefSerial = txtNombres.Text;

            return objReferencia;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro del paciente
            Referencia objReferencia = GetEntity();
            // Enviar a la capa de logica de negocio
            bool response = ReferenciaLN.getInstance().RegistrarReferencia(objReferencia);
            if (response == true)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");

            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
        }
    }
}