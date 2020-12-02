using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;


namespace MedicinalFinal.GUI
{
    public partial class ModoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }
        void GetData()
        {

            var client = new RestClient("https://localhost:44334/api/MethodPayment");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<DataList>(content);
            gnv_pago.DataSource = result.data;
            gnv_pago.DataBind();
        }
        public class data
        {
            public int paymentId { get; set; }
            public string methodName { get; set; }
  

        }
        public class DataList
        {
            public List<data> data { get; set; }
        }
        protected void gnv_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Text = gnv_pago.SelectedRow.Cells[0].Text;
                txt_nombre.Text = gnv_pago.SelectedRow.Cells[1].Text;
               

            }
            catch (Exception)
            {
            }
        }

        protected void gnv_pago_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gnv_pago, "Select$" + e.Row.RowIndex);
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
           
        }
        //Agregar
        public void PostData()
        {
            //int Id = Convert.ToInt32(Txt_id.Text);
            string methodName = txt_nombre.Text;
        
            var client = new RestClient("https://localhost:44334/api/MethodPayment");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {

                methodName = methodName,
             
            });
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            string methodName = txt_nombre.Text;

            var client = new RestClient("https://localhost:44334/api/MethodPayment");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                methodName = methodName,
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/MethodPayment");
            var request = new RestRequest("/" + Id, Method.DELETE);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
    }
}