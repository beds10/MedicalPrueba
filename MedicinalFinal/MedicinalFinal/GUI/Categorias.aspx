<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="MedicinalFinal.GUI.Categorias" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class=" container">
        <!--Primera fila-->
        <div class="Row">
            <h1 class="h1">Gestionamiento de Categoria</h1>
        </div>
        <br />
        <br />
        <!--Segunda fila-->
        <div class="Row">
            <!--Primera columna-->
          
             <div class=" Col-md-3 card  " style="width: 30%; position:absolute ">
               <h5 class="card-header">Categorias</h5>
              <div class="card-body">
                <div class="form-group">

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">ID Categoria</span>
                       </div>
    
                        <asp:TextBox ID="txt_id" type="text" aria-label="Last name" class="form-control" runat="server"></asp:TextBox>
                   
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Nombre Categoria</span>
                       </div>
                        <asp:TextBox ID="txt_categoria" type="text" aria-label="Last name" class="form-control" runat="server"></asp:TextBox>
                    </div>
                 
               </div>
                  <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btn_Guardar_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btn_Eliminar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Btn_Actualizar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="Btn_Actualizar_Click" />
               </div>
             </div>
       
            <!--Segunda Columna -->
           <div class=" Col-md-3 card" style="right:-600px; width:40%" >
                <h5 class="card-header">Lista de Categorias</h5>
               <div class="card-body">
                  <asp:GridView ID="gvt_categorias" runat="server" OnRowDataBound="gvt_categorias_RowDataBound" OnSelectedIndexChanged="gvt_categorias_SelectedIndexChanged"></asp:GridView>
               </div>
          </div>  
        </div>
    </div>
    
</asp:Content>
