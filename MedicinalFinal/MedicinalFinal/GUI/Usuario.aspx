<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="MedicinalFinal.GUI.Usuario" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <br />
    <br />
    <div class=" container">
        <!--Primera fila-->
        <div class="Row">
            <h1 class="h1">Gestionamiento de Usuarios</h1>
        </div>
        <br />
        <br />
        <!--Segunda fila-->
        <div class="Row">
            <!--Primera columna-->
          
             <div class=" Col-md-3 card  " style="width: 30%; position:absolute ">
               <h5 class="card-header">Usuarios</h5>
              <div class="card-body">
                <div class="form-group">
                   
                  
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">ID Usuario</span>
                       </div>
                      <asp:TextBox ID="txt_id" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Nombre </span>
                       </div>
                      <asp:TextBox ID="txt_nombre" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>
                 <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Correo </span>
                       </div>
                      <asp:TextBox ID="txt_correo" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Contraseña </span>
                       </div>
                      <asp:TextBox ID="txt_contr" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Direccion </span>
                       </div>
                      <asp:TextBox ID="txt_dire" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Celular </span>
                       </div>
                      <asp:TextBox ID="txt_cel" runat="server" type="text" aria-label="Last name" class="form-control"></asp:TextBox>                    
                   
                    </div>

                    <br />
                   <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Tipo de usario</span>
                       </div>
                       <asp:DropDownList ID="dpl_tipo_usuario" runat="server" class="dropdown"></asp:DropDownList>
                    </div>
               </div>
                  <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btn_Guardar_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btn_Eliminar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Btn_Actualizar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="Btn_Actualizar_Click" />
               </div>
             </div>
       
            <!--Segunda Columna -->
           <div class=" Col-md-3 card" style="right:-600px; width:40%" >
                <h5 class="card-header">Lista de Usuarios</h5>
               <div class="card-body">
                  <asp:GridView ID="gdv_usuarios" runat="server" OnRowDataBound="gdv_usuarios_RowDataBound" OnSelectedIndexChanged="gdv_usuarios_SelectedIndexChanged"></asp:GridView>
               </div>
          </div>  
        </div>
    </div>
</asp:Content>
