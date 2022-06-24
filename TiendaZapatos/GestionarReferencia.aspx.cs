using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (!Page.IsPostBack)
            {
                
            }
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