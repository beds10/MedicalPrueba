using Newtonsoft.Json;
using RestSharp;
using Stripe;
using Stripe.BillingPortal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MedicinalFinal.GUI
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_51GzTkiGuto1on93IjsTQTO8g2GyGcxc3zDkakKMhvWq1ccdbwfzdBAikQD72PAaatAbb2belEq5Cl1lV2WhxyMqL00b7iwXHKK";
            txt_id.Enabled = false;
            GetData();
            if (!IsPostBack)
            {
                llenarcategoria();
                llenarEstatus();
                llenarfarmacia();
            }
        }
       
        void GetData()
        {
           
            var client = new RestClient("https://localhost:44334/api/Product");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<DataList>(content);
            gdv_productos.DataSource = result.data;
            gdv_productos.DataBind();
        }
        public class data
        {

            public int productoId { get; set; }
            public string productImage { get; set; }
            public string name { get; set; }
            public string uPrice { get; set; }
            public int stock { get; set; }
            public string description { get; set; }
            public int categoryPrId { get; set; }
            public int statusPrId { get; set; }
            public int pharmacyPrId { get; set; }   
            public string product_stripe { get; set; }
            public string price_stripe { get; set; }
        }
        public class DataList
        {
            public List<data> data { get; set; }
        }

        protected void gdv_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 txt_id.Text= gdv_productos.SelectedRow.Cells[0].Text;
                txt_nombre.Text = gdv_productos.SelectedRow.Cells[2].Text;
                txt_precio.Text = gdv_productos.SelectedRow.Cells[3].Text;
                txt_stoc.Text = gdv_productos.SelectedRow.Cells[4].Text;
                txt_des.Text = gdv_productos.SelectedRow.Cells[5].Text;
                dpl_categoria.Text = gdv_productos.SelectedRow.Cells[6].Text;
                dpl_estatus.Text = gdv_productos.SelectedRow.Cells[7].Text;
               dpl_farmacia.Text = gdv_productos.SelectedRow.Cells[8].Text;
               txt_pro_strip.Text = gdv_productos.SelectedRow.Cells[9].Text;
                txt_pre_stripe.Text = gdv_productos.SelectedRow.Cells[10].Text;



            }
            catch (Exception)
            {
            }

        }

        protected void gdv_productos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    Page.ClientScript.GetPostBackClientHyperlink
                    (gdv_productos, "Select$" + e.Row.RowIndex);
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
        public void Clear()
        {
         
            txt_id.Text = "";
            txt_nombre.Text  ="";
            txt_precio.Text = "";
            txt_stoc.Text  = "";
            txt_des.Text  = "";
            txt_pre_stripe.Text = "";
            txt_pro_strip.Text = "";
        }
        //Agregar
        string product_stripe;
        string price_stripe;
        String numero = "";
        string img1;
        public void PostData()
        {

            Random random = new Random();
        
            for (int i = 0; i < 10; i++)
            {
                numero += Convert.ToString(random.Next(0, 9));

            }



            img1 = System.IO.Path.Combine(Server.MapPath("~/images/productos/" + "img_prin_" + numero + ".png"));   // genero la ruta para haga que la imagen se almacene en mi proyecto
            FileUpload1.SaveAs(img1); //guardo la imagen 



            string uPrice = txt_precio.Text;
            string pricestripe;
            pricestripe = txt_precio.Text + "00";
            saveproduct(txt_nombre.Text);
            getproduct();
            saveprice(Convert.ToInt32(pricestripe),product_stripe);
            getprice();

            //   int productoId: = Convert.ToInt32(Txt_id.Text);

            string name = txt_nombre.Text;
           
            string stock = txt_stoc.Text;
            string description = txt_des.Text;
            int categoryPrId = Convert.ToInt32(dpl_categoria.Text);
            int statusPrId = Convert.ToInt32(dpl_estatus.Text);
            int pharmacyPrId = Convert.ToInt32(dpl_farmacia.Text);

  

           

   

            //se utiliza un metodo http Post para agregar fatos en la url
            var client = new RestClient("https://localhost:44334/api/Product");
            var request = new RestRequest(Method.POST);
            //se convierten en formato json 
            request.RequestFormat = DataFormat.Json;
            //se declaran las variables con un metodo costructor , igualando los datos json con las varibales de la lista data
            request.AddJsonBody(new
            {

                name = name,
                productImage = "img_prin_" + numero + ".png",
                uPrice = uPrice,
                stock = stock,
                description = description,
                categoryPrId = categoryPrId,
                statusPrId = statusPrId,
                pharmacyPrId = pharmacyPrId,
                product_stripe = product_stripe,
                price_stripe = price_stripe
            });
            //ejecuta la sentencia
            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Actualizar
        public void saveproduct(string nombre)
        {
            var options = new ProductCreateOptions
            {
                Name = nombre,
            };
            var service = new ProductService();
            service.Create(options);

        }
        public void getproduct()
        {
            var options2 = new ProductListOptions
            {
                Limit = 1,
            };
            var service2 = new ProductService();
            StripeList<Product> products = service2.List(options2);

            foreach (var product in products.Data)
            {
                product_stripe = product.Id;

            }
        }
        public void saveprice(Decimal price, string product)
        {
            var options3 = new PriceCreateOptions
            {
                UnitAmountDecimal = price,
                Currency = "mxn",
                Product = product,
         
            };
            var service3 = new PriceService();
            service3.Create(options3);
        }
        public void getprice()
        {

            var options4 = new PriceListOptions { Limit = 1 };
            var service4 = new PriceService();
            StripeList<Price> prices = service4.List(options4);

            foreach (var price in prices.Data)
            {
                price_stripe = price.Id;

            }
        }
      
        public void PutActualizar()
        {
            int Id = Convert.ToInt32(txt_id.Text);
            string name = txt_nombre.Text;
            string uPrice = txt_precio.Text;
            string stock = txt_stoc.Text;
            string description = txt_des.Text;
            int categoryPrId = Convert.ToInt32(dpl_categoria.Text);
            int statusPrId = Convert.ToInt32(dpl_estatus.Text);
            int pharmacyPrId = Convert.ToInt32(dpl_farmacia.Text);
            int product_stripe = Convert.ToInt32(txt_pro_strip.Text);
            int price_stripe = Convert.ToInt32(txt_pre_stripe.Text);

            var client = new RestClient("https://localhost:44334/api/Product");
            var request = new RestRequest("?id=" + Id, Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                name = name,
                uPrice = uPrice,
                stock = stock,
                description = description,
                categoryPrId = categoryPrId,
                statusPrId = statusPrId,
                pharmacyPrId = pharmacyPrId,
                product_stripe = product_stripe,
                price_stripe = price_stripe
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
        //Eliminar
        public void Delete()
        {
            int Id = Convert.ToInt32(txt_id.Text);

            var client = new RestClient("https://localhost:44334/api/Product");
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
        public void llenarfarmacia()
        {

            dpl_farmacia.DataSource = Consultar("Select*from Farmacias ");
            dpl_farmacia.DataTextField = "nombre";
            dpl_farmacia.DataValueField = "id_farmacia";
            dpl_farmacia.DataBind();
            dpl_farmacia.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
        public void llenarcategoria()
        {

            dpl_categoria.DataSource = Consultar("Select*from Categorias ");
            dpl_categoria.DataTextField = "nombre";
           dpl_categoria.DataValueField = "id_categorias";
            dpl_categoria.DataBind();
            dpl_categoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }
    }
}