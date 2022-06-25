using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace TiendaZapatos
{
    public partial class GestionarStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenadoDropDown();
            }
            
        }


        [WebMethod]
        public static List<Stock> ListarStock()
        {
            List<Stock> Lista = null;
            try
            {
                Lista = StockLN.getInstance().ListarStock();
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarDatosStock(String id, String serial)
        {
            Stock objStock = new Stock()
            {
                idStock = Convert.ToInt32(id),
                serial = serial
            };

            bool ok = StockLN.getInstance().Actualizar(objStock);
            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosStock(String id)
        {
            Int32 idStock = Convert.ToInt32(id);

            bool ok = StockLN.getInstance().Eliminar(idStock);

            return ok;

        }

        private void LlenadoDropDown()
        {
            dropReferencia.DataSource = Consultar("SELECT * FROM Referencia");
            dropReferencia.DataTextField = "nomReferencia"; // esta es la consulta
            dropReferencia.DataValueField = "nomReferencia"; // este es el que envia como variable VALOR
            dropReferencia.DataBind();
            dropReferencia.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        public DataSet Consultar(string strSQL)
        {
            string strconn = @"Data Source=LAPTOP-7JSP6FE5\SQLEXPRESS; Initial Catalog=DBZapatos; User ID=sa; Password=4oct2001";
            SqlConnection con = new SqlConnection(strconn);
            con.Open();
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        private Stock GetEntity()
        {
            Stock objStock = new Stock();
            objStock.idStock = 0;
            objStock.serial = txtSerial.Text;
            string nR = dropReferencia.SelectedValue;   // captura de valor a variable reasignable
            objStock.nomReferencia = nR;
            return objStock;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro del paciente
            Stock objStock = GetEntity();
            // Enviar a la capa de logica de negocio
            bool response = StockLN.getInstance().RegistrarStock(objStock);
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