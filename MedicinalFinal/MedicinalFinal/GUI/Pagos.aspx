<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGUI/Menu.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="MedicinalFinal.GUI.Pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script>
        function total() {
            dinero = 100;
        }
    </script>
     
   <form>
       <label>Ingrese dinero</label>
       <asp:TextBox ID="txt_cant" class="form-control" runat="server">100</asp:TextBox>
  <script
    src="https://www.paypal.com/sdk/js?client-id=sb"> // Required. Replace SB_CLIENT_ID with your sandbox client ID.
  </script>

  <div id="paypal-button-container"></div>
  
       
  <script>
      paypal.Buttons({
          createOrder: function (data, actions) {
            obj = 100;
              // This function sets up the details of the transaction, including the amount and line item details.
              return actions.order.create({
                  purchase_units: [{
                      amount: {
                          value: obj
                      }
                  }]
              });
          },
          onApprove: function (data, actions) {
              // This function captures the funds from the transaction.
              return actions.order.capture().then(function (details) {
                  // This function shows a transaction success message to your buyer.
                  alert('Transaction completed by ' + details.payer.name.given_name);
              });
          }
      }).render('#paypal-button-container');
  //This function displays Smart Payment Buttons on your web page.
  </script>
</form>

</asp:Content>
