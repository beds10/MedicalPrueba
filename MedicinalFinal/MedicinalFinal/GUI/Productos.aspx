<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="MedicinalFinal.GUI.Productos" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <div class=" container">
        <!--Primera fila-->
        <div class="Row">
            <h1 class="h1">Gestionamiento de Productos</h1>
        </div>
        <br />
        <br />
        <!--Segunda fila-->
        <div class="Row">
            <!--Primera columna-->
          
             <div class=" Col-md-3 card  " style="width: 30%; position:absolute ">
               <h5 class="card-header">Productos</h5>
              <div class="card-body">
                <div class="form-group">

               

                    <div class="input-group mb-3">
                      <div class="input-group-prepend">
                       <span class="input-group-text" id="inputGroupFileAddon01">Upload</span>
                       </div>
                          <asp:FileUpload ID="FileUpload1" runat="server" />
        
                   </div>

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Id Producto</span>
                       </div>
                      <asp:TextBox ID="txt_id" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Nombre del Producto</span>
                       </div>
                      <asp:TextBox ID="txt_nombre" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Precio</span>
                       </div>
                      <asp:TextBox ID="txt_precio" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Stock</span>
                       </div>
                      <asp:TextBox ID="txt_stoc" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Descripcion</span>
                       </div>
                        <asp:TextBox ID="txt_des" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Producto stripe</span>
                       </div>
                        <asp:TextBox ID="txt_pro_strip" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Price stripe</span>
                       </div>
                        <asp:TextBox ID="txt_pre_stripe" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  
                    
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Estatus</span>
                       </div>
                       <asp:DropDownList ID="dpl_estatus" runat="server" class="dropdown"  > </asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Farmacia</span>
                       </div>
                          <asp:DropDownList ID="dpl_farmacia" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Categoria</span>
                       </div>
                      <asp:DropDownList ID="dpl_categoria" runat="server" class="dropdown"></asp:DropDownList>
                    </div>

               </div>
                  <asp:Button ID="btn_Guardar"  clientIdMode="static" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btn_Guardar_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btn_Eliminar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Btn_Actualizar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="Btn_Actualizar_Click" />
               </div>
             </div>
                <script src="https://js.stripe.com/v3/"></script>
      
            <!--Segunda Columna -->
           <div class=" Col-md-3 card" style="right:-600px; width:40%" >
                <h5 class="card-header">Lista de Productos</h5>
               <div class="card-body">
                  <asp:GridView ID="gdv_productos" runat="server" OnRowDataBound="gdv_productos_RowDataBound" OnSelectedIndexChanged="gdv_productos_SelectedIndexChanged"></asp:GridView>
               </div>
          </div>  
        </div>
    </div>
</asp:Content>
