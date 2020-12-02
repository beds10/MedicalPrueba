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
    public partial class Farmacias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
            if (!IsPostBack)
            {
           
                llenarEstatus();
               
            }
        }
        void GetData()
        {

            var client = new RestClient("https://localhost:44334/api/Pharmacy");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<DataList>(content);
            gdv_farmacia.DataSource = result.data;
            gdv_farmacia.DataBind();
        }
        public class data
        {
            public int pharmaId { get; set; }
            public string name { get; set; }
            public string adress { get; set; }
            public float longitude { get; set; }
            public float latitude { get; set; }
            public int statusPId { get; set; }

        }
        public class DataList
        {
            public List<data> data { get; set; }
        }
        protected void gdv_farmacia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Text =gdv_farmacia.SelectedRow.Cells[0].Text;
                txt_nombre.Text = gdv_farmacia.SelectedRow.Cells[1].Text;
                txt_direccion.Text = gdv_farmacia.SelectedRow.Cells[2].Text;
                txt_longitud.Text = gdv_farmacia.SelectedRow.Cells[3].Text;
                txt_latitud.Text = gdv_farmacia.SelectedRow.Cells[4].Text;
                dpl_estatus.Text = gdv_farmacia.SelectedRow.Cells[5].Text;

            }
            catch (Exception)
            {
            }

        }

        protected void gdv_farmacia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gdv_farmacia, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombre.Text == "")
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
            txt_nombre.Text = "";
            txt_direccion.Text = "";
            txt_longitud.Text = "";
            txt_latitud.Text = "";
        }
        //Agregar
        public void PostData()
        {
            //int Id = Convert.ToInt32(Txt_id.Text);
            string name = txt_nombre.Text;
            string adress = txt_direccion.Text;
            float longitude =Convert.ToInt32(txt_longitud.Text);
            float latitude = Convert.ToInt32(txt_latitud.Text);
            int statusPId = Convert.ToInt32(dpl_estatus.Text);
            var client = new RestClient("https://localhost:44334/api/Pharmacy");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {

                name = name,
                adress = adress,
                longitude = longitude,
                latitude = latitude,
                statusPId = statusPId
            });
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            string name = txt_nombre.Text;
            string adress = txt_direccion.Text;
            float longitude = Convert.ToInt32(txt_longitud.Text);
            float latitude = Convert.ToInt32(txt_latitud.Text);
            int statusPId = Convert.ToInt32(dpl_estatus.Text);

            var client = new RestClient("https://localhost:44334/api/Pharmacy");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                name = name,
                adress = adress,
                longitude = longitude,
                latitude = latitude,
                statusPId = statusPId
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/Pharmacy");
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