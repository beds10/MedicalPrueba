using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Librerias que ocupamos para la recoleccion y tranformacion de datos
//el json no sirvio para  deserealizar los datos 
using Newtonsoft.Json;
//restsharp nos sirvio para consumir la API  y menod linea codigo en la conexion con la API.
using RestSharp;

namespace MedicinalFinal.GUI
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nos  Ayudan  obtener los datos de la Url en el siguiente metodo
            GetData();

        }
        void GetData()
        {
            //url de la API
            var client = new RestClient("https://localhost:44334/api/Category");

            //con un metodo http Get  para traer datos 
            var request = new RestRequest(Method.GET);

            //Respuesta de la Api y almazena el contido de la respuesta en una variable que contiene el json 
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            //se desearilizar  el json  en un objeto lista , que contiene las variables de la tabla al cual pertenece esa consulta
            var result = JsonConvert.DeserializeObject<DataList>(content);
            //llena el gridview con los datos solicitados con la correspondiente consulta
            gvt_categorias.DataSource = result.data;
            gvt_categorias.DataBind();
        }
        //Se almazenan los datos de la consulta de la url

        public class data
        {
            public int categoryId { get; set; }
            public string name { get; set; }

        }
        //se almacenan los datos en una lista, la cual va ser cosumida por el metodo inicial  Get para el gridview
        public class DataList
        {
            public List<data> data { get; set; }
        }

        protected void gvt_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_id.Text = gvt_categorias.SelectedRow.Cells[0].Text;
                txt_categoria.Text = gvt_categorias.SelectedRow.Cells[1].Text;
            }
            catch (Exception)
            {
            }
        }

        protected void gvt_categorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gvt_categorias, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_categoria.Text == "")
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
            txt_categoria.Text = "";
        }
        //Agregar
        public void PostData()
        {
            //int Id = Convert.ToInt32(Txt_id.Text);
            string name = txt_categoria.Text;//se iguala los datos del texbox a una variable

            //se utiliza un metodo http Post para agregar fatos en la url
            var client = new RestClient("https://localhost:44334/api/Category");
            var request = new RestRequest(Method.POST);
            //se convierten en formato json 
            request.RequestFormat = DataFormat.Json;
            //se declaran las variables con un metodo costructor , igualando los datos json con las varibales de la lista data
            request.AddJsonBody(new
            {

                name = name,
            });
            //ejecuta la sentencia
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            string name = txt_categoria.Text;

            var client = new RestClient("https://localhost:44334/api/Category");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                name = name,
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/Category");
            var request = new RestRequest("/" + Id, Method.DELETE);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
    }
}