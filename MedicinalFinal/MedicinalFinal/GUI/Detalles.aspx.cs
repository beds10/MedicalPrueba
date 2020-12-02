using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MedicinalFinal.GUI
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
            if (!IsPostBack)
            {
                llenarpedido();
                llenarproducto();
                llenartipodepago();
            }
        }
        void GetData()
        {

            var client = new RestClient("https://localhost:44334/api/Detailord");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<DataList>(content);
            gdv_detalles.DataSource = result.data;
            gdv_detalles.DataBind();
        }
        public class data
        {
            public int detailId { get; set; }
            public int quantity { get; set; }
            public float totalprice { get; set; }
            public int productDId { get; set; }
            public int orderDId { get; set; }
            public int paymentMethodDId { get; set; }

        }
        public class DataList
        {
            public List<data> data { get; set; }
        }

        protected void gdv_detalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Text = gdv_detalles.SelectedRow.Cells[0].Text;
                txt_cantidas.Text = gdv_detalles.SelectedRow.Cells[1].Text;
                txt_precio.Text = gdv_detalles.SelectedRow.Cells[2].Text;
                dpl_producto.Text = gdv_detalles.SelectedRow.Cells[3].Text;
                dpl_pedido.Text = gdv_detalles.SelectedRow.Cells[4].Text;
                dpl_tipo_pago.Text = gdv_detalles.SelectedRow.Cells[5].Text;

            }
            catch (Exception)
            {
            }
        }

        protected void gdv_detalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gdv_detalles, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cantidas.Text == "")
                {

                }
                else
                {
                    PostData();
                    Clear();
                }

            }
            catch (Exception)
            {

            }
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
                Clear();
            }
            catch (Exception)
            {

            }
        }

        protected void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                PutActualizar();
                Clear();
            }
            catch (Exception)
            {
            }
        }
        //Limpiar
        public void Clear()
        {
            txt_id.Text = "";
            txt_cantidas.Text = "";
            txt_precio.Text = "";
            
         
        }
        //Agregar
        public void PostData()
        {
            //int Id = Convert.ToInt32(Txt_id.Text);
            
            float quantity = Convert.ToInt32( txt_cantidas.Text);
            int totalprice = Convert.ToInt32(txt_precio.Text);
            int productDId = Convert.ToInt32(dpl_producto.Text);
            int orderDId = Convert.ToInt32(dpl_pedido.Text);
            int paymentMethodDId = Convert.ToInt32(dpl_tipo_pago.Text); 
            var client = new RestClient("https://localhost:44334/api/Detailord");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {

                quantity = quantity,
                totalprice = totalprice,
                productDId = productDId,
                orderDId = orderDId,
                paymentMethodDId = paymentMethodDId
            });
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            float quantity = Convert.ToInt32(txt_cantidas.Text);
            int totalprice = Convert.ToInt32(txt_precio.Text);
            int productDId = Convert.ToInt32(dpl_producto.Text);
            int orderDId = Convert.ToInt32(dpl_pedido.Text);
            int paymentMethodDId = Convert.ToInt32(dpl_tipo_pago.Text);

            var client = new RestClient("https://localhost:44334/api/Detailord");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                quantity = quantity,
                totalprice = totalprice,
                productDId = productDId,
                orderDId = orderDId,
                paymentMethodDId = paymentMethodDId
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/Detailord");
            var request = new RestRequest("/" + Id, Method.DELETE);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        public DataSet Consultar(string strsql)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strsql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;

            }

        }
        public void llenarproducto()
        {

            dpl_producto.DataSource = Consultar("Select*from Productos");
            dpl_producto.DataTextField = "nombre";
            dpl_producto.DataValueField = "id_productos";
            dpl_producto.DataBind();
            dpl_producto.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
        public void llenarpedido()
        {

            dpl_pedido.DataSource = Consultar("Select*from Pedidos ");
            dpl_pedido.DataTextField = "id_pedidos";
            dpl_pedido.DataValueField = "id_pedidos";
            dpl_pedido.DataBind();
            dpl_pedido.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
        public void llenartipodepago()
        {

            dpl_tipo_pago.DataSource = Consultar("Select*from Modo_pago ");
            dpl_tipo_pago.DataTextField = "nombre_pago";
            dpl_tipo_pago.DataValueField = "id_pago";
            dpl_tipo_pago.DataBind();
            dpl_tipo_pago.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
    }
}