using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;


namespace MedicinalFinal.GUI
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
            if (!IsPostBack)
            {
              llenardrop();
            }
            
        }
        public DataSet Consultar(string strsql)
        {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(strsql,con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    return ds;

                }
    
        }
        public void llenardrop()
        {
            
            dpl_tipo_usuario.DataSource = Consultar("Select*from Perfil ");
            dpl_tipo_usuario.DataTextField = "nombre";
            dpl_tipo_usuario.DataValueField = "id_perfil";
            dpl_tipo_usuario.DataBind();
            dpl_tipo_usuario.Items.Insert(0, new ListItem("[Seleccionar]","0"));
        }
        void GetData()
        {

            var client = new RestClient("https://localhost:44334/api/User");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<DataList>(content);
            gdv_usuarios.DataSource = result.data;
            gdv_usuarios.DataBind();
        }
        public class data
        {
            public int userId { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string pass { get; set; }
            public string direction { get; set; }
            public int numberCellphone { get; set; }
            public int profileId { get; set; }

        }
        public class DataList
        {
            public List<data> data { get; set; }
        }
        protected void gdv_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Text = gdv_usuarios.SelectedRow.Cells[0].Text;
                txt_nombre.Text = gdv_usuarios.SelectedRow.Cells[1].Text;
                txt_correo.Text = gdv_usuarios.SelectedRow.Cells[2].Text;
                txt_contr.Text =gdv_usuarios.SelectedRow.Cells[3].Text;
                txt_dire.Text = gdv_usuarios.SelectedRow.Cells[4].Text;
                txt_cel.Text = gdv_usuarios.SelectedRow.Cells[5].Text;
                dpl_tipo_usuario.Text = gdv_usuarios.SelectedRow.Cells[5].Text;

            }
            catch (Exception)
            {
            }
        }

        protected void gdv_usuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gdv_usuarios, "Select$" + e.Row.RowIndex);
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
            txt_correo.Text = "";
            txt_contr.Text = "";
            txt_dire.Text = "";
            txt_cel.Text = "";
            dpl_tipo_usuario.Text = "";
        }
        //Agregar
        public void PostData()
        {
            //int Id = Convert.ToInt32(Txt_id.Text);
            string name = txt_nombre.Text;
            string email = txt_correo.Text;
            string pass = txt_contr.Text;
            string direction = txt_dire.Text;
            int numberCellphone = Convert.ToInt32(txt_cel.Text);
            int profileId = Convert.ToInt32(dpl_tipo_usuario.Text);
            var client = new RestClient("https://localhost:44334/api/User");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {

                name = name,
                email = email,
                pass = pass,
                direction = direction,
                numberCellphone = numberCellphone,
                profileId = profileId
            });
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            string name = txt_nombre.Text;
            string email = txt_correo.Text;
            string pass = txt_contr.Text;
            string direction = txt_dire.Text;
            int numberCellphone = Convert.ToInt32(txt_cel.Text);
            int profileId = Convert.ToInt32(dpl_tipo_usuario.Text);

            var client = new RestClient("https://localhost:44334/api/User");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                name = name,
                email = email,
                pass = pass,
                direction = direction,
                numberCellphone = numberCellphone,
                profileId = profileId

            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/User");
            var request = new RestRequest("/" + Id, Method.DELETE);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
    }
}