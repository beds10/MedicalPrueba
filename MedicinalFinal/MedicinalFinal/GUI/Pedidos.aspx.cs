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
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            GetData();
            if (!IsPostBack)
            {
                llenarEstatus();
                llenarfarmacia();
                llenarproducto();
                llenarUsuario();
            }
        }
        void GetData()
        {

            var client = new RestClient("https://localhost:44334/api/Order");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<DataList>(content);
            gdv_pedidos.DataSource = result.data;
            gdv_pedidos.DataBind();
        }
        public class data
        {
            public int orderId { get; set; }
            public string destination { get; set; }
            public string session_token { get; set; }
            public string total_compra { get; set; }

            
            public int pharmOId { get; set; }
            public int productOId { get; set; }
            public int userOId { get; set; }
            public int statusOId { get; set; }

        }
        public class DataList
        {
            public List<data> data { get; set; }
        }
        protected void gdv_pedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Text = gdv_pedidos.SelectedRow.Cells[0].Text;
                txt_direccion.Text = gdv_pedidos.SelectedRow.Cells[1].Text;
                txt_session.Text = gdv_pedidos.SelectedRow.Cells[2].Text;
                txt_total.Text = gdv_pedidos.SelectedRow.Cells[3].Text;
            }
            catch (Exception)
            {
            }
        }

        protected void gdv_pedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gdv_pedidos, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_direccion.Text == "")
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
            txt_direccion.Text = "";
           
        }
        //Agregar
        public void PostData()
        {
            //int Id = Convert.ToInt32(Txt_id.Text);
            string destination = txt_direccion.Text;
            string total = txt_total.Text;
            string session = txt_session.Text;
            int pharmOId = Convert.ToInt32(dpl_farmacia.Text);
            int productOId = Convert.ToInt32(dpl_producto.Text);
            int userOId = Convert.ToInt32(dpl_usuario.Text);
            int statusPId = Convert.ToInt32(dpl_estatus.Text);

            var client = new RestClient("https://localhost:44334/api/Order");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {

                destination = destination,
                session_token = session,
                total_compra = total,
                pharmOId = pharmOId,
                productOId = productOId,
                userOId = userOId,
                statusPId = statusPId
            });
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            string destination = txt_direccion.Text;
            string total = txt_total.Text;
            string session = txt_session.Text;
            int pharmOId = Convert.ToInt32(dpl_farmacia.Text);
            int productOId = Convert.ToInt32(dpl_producto.Text);
            int userOId = Convert.ToInt32(dpl_usuario.Text);
            int statusPId = Convert.ToInt32(dpl_estatus.Text);


            var client = new RestClient("https://localhost:44334/api/Order");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {

                destination = destination,
                session_token = session,
                total_compra = total,
                pharmOId = pharmOId,
                productOId = productOId,
                userOId = userOId,
                statusPId = statusPId
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/Order");
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
        public void llenarfarmacia()
        {

            dpl_farmacia.DataSource = Consultar("Select*from Farmacias ");
            dpl_farmacia.DataTextField = "nombre";
            dpl_farmacia.DataValueField = "id_farmacia";
            dpl_farmacia.DataBind();
            dpl_farmacia.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
        public void llenarproducto()
        {

            dpl_producto.DataSource = Consultar("Select*from Productos");
            dpl_producto.DataTextField = "nombre";
            dpl_producto.DataValueField = "id_productos";
            dpl_producto.DataBind();
            dpl_producto.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
        public void llenarUsuario()
        {

            dpl_usuario.DataSource = Consultar("Select*from Usuarios ");
            dpl_usuario.DataTextField = "nombre";
            dpl_usuario.DataValueField = "id_usuario";
            dpl_usuario.DataBind();
            dpl_usuario.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
        public void llenarEstatus()
        {

            dpl_estatus.DataSource = Consultar("Select*from Estatus ");
            dpl_estatus.DataTextField = "nombre_status";
            dpl_estatus.DataValueField = "id_estatus";
            dpl_estatus.DataBind();
            dpl_estatus.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
    }
}