<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="MedicinalFinal.GUI.Pedidos" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <br />
    <div class=" container">
        <!--Primera fila-->
        <div class="Row">
            <h1 class="h1">Gestionamiento de Pedidos</h1>
        </div>
        <br />
        <br />
        <!--Segunda fila-->
        <div class="Row">
            <!--Primera columna-->
          
             <div class=" Col-md-3 card  " style="width: 30%; position:absolute ">
               <h5 class="card-header">Pedidos</h5>
              <div class="card-body">
                <div class="form-group">

                  
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Id del pedido</span>
                       </div>
                           <asp:TextBox ID="txt_id" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Direccion </span>
                       </div>
                          <asp:TextBox ID="txt_direccion" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>

                              <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Session Token </span>
                       </div>
                          <asp:TextBox ID="txt_session" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>

                              <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Total Compra </span>
                       </div>
                          <asp:TextBox ID="txt_total" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Farmacia</span>
                       </div>
                        <asp:DropDownList ID="dpl_farmacia" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Producto</span>
                       </div>
                     <asp:DropDownList ID="dpl_producto" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Usuario</span>
                       </div>
                      <asp:DropDownList ID="dpl_usuario" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Estatus</span>
                       </div>
                       <asp:DropDownList ID="dpl_estatus" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                   
                    
                    
                    



              </div>
                  <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btn_Guardar_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btn_Eliminar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Btn_Actualizar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="Btn_Actualizar_Click" />
               </div>
             </div>
       
            <!--Segunda Columna -->
           <div class=" Col-md-3 card" style="right:-600px; width:40%" >
                <h5 class="card-header">Lista de Pedidos</h5>
               <div class="card-body">
                  <asp:GridView ID="gdv_pedidos" runat="server" OnRowDataBound="gdv_pedidos_RowDataBound" OnSelectedIndexChanged="gdv_pedidos_SelectedIndexChanged"></asp:GridView>
               </div>
          </div>  
        </div>
    </div>
</asp:Content>
