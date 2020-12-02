<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="FotosUsuario.aspx.cs" Inherits="MedicinalFinal.GUI.FotosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <br />
    <div class=" container">
        <!--Primera fila-->
        <div class="Row">
            <h1 class="h1">Gestionamiento de Fotos</h1>
        </div>
        <br />
        <br />
        <!--Segunda fila-->
        <div class="Row">
            <!--Primera columna-->
          
             <div class=" Col-md-3 card  " style="width: 30%; position:absolute ">
               <h5 class="card-header">Fotos</h5>
              <div class="card-body">
                <div class="form-group">

                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">ID de Foto</span>
                       </div>
                      <input type="text" aria-label="Last name" class="form-control">
                    </div>
                    <br />
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">Seleccionar foto</span>
                       </div>
                      <input type="text" aria-label="Last name" class="form-control">
                    </div>
                    <div class="input-group">
                       <div class="input-group-prepend">
                        <span class="input-group-text">ID perfil</span>
                       </div>
                      <input type="text" aria-label="Last name" class="form-control">
                    </div>
                 
               </div>
                  <button type="submit" class="btn btn-primary">Guardar</button>&nbsp;&nbsp;&nbsp;&nbsp;
                  <button type="submit" class="btn btn-danger">Eliminar</button>&nbsp;&nbsp;&nbsp;&nbsp;
                  <button type="submit" class="btn btn-success">Actualizar</button>
               </div>
             </div>
       
            <!--Segunda Columna -->
           <div class=" Col-md-3 card" style="right:-600px; width:40%" >
                <h5 class="card-header">Lista de Categorias</h5>
               <div class="card-body">
                  <asp:GridView ID="GridView1" runat="server"></asp:GridView>
               </div>
          </div>  
        </div>
    </div>
</asp:Content>
