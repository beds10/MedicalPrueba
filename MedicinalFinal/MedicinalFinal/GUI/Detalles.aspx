<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="MedicinalFinal.GUI.Detalles"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <div class=" container">
        <!--Primera fila-->
        <div class="Row">
            <h1 class="h1">Gestionamiento de Detalles</h1>
        </div>
        <br />
        <br />
        <!--Segunda fila-->
        <div class="Row">
            <!--Primera columna-->
          
             <div class=" Col-md-3 card  " style="width: 30%; position:absolute ">
               <h5 class="card-header">Detalles de productos</h5>
              <div class="card-body">
                <div class="form-group">

                  
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Id del detalle</span>
                       </div>
                      <asp:TextBox ID="txt_id" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                 
                    </div>

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Cantidad </span>
                       </div>
                      <asp:TextBox ID="txt_cantidas" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                 
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Precio </span>
                       </div>
                      <asp:TextBox ID="txt_precio" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                 
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Producto</span>
                       </div>
                        <asp:DropDownList ID="dpl_producto" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Pedido</span>
                       </div>
                        <asp:DropDownList ID="dpl_pedido" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Tipo de pago</span>
                       </div>
                       <asp:DropDownList ID="dpl_tipo_pago" runat="server" class="dropdown"></asp:DropDownList>
                    </div>

                 </div>
                  <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btn_Guardar_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btn_Eliminar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Btn_Actualizar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="Btn_Actualizar_Click" />
               </div>
             </div>
             </div>
       
            <!--Segunda Columna -->
           <div class=" Col-md-3 card" style="right:-600px; width:40%" >
                <h5 class="card-header">Lista de Detalles</h5>
               <div class="card-body">
                  <asp:GridView ID="gdv_detalles" runat="server" OnRowDataBound="gdv_detalles_RowDataBound" OnSelectedIndexChanged="gdv_detalles_SelectedIndexChanged"></asp:GridView>
               </div>
          </div>  
        </div>
    </div>
</asp:Content>
