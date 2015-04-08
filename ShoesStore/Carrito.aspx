<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ShoesStore.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-body">
         <asp:TextBox ID="IdCarritoTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="IdCalzadoTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>

        <asp:DropDownList ID="FormaPagoDropDownList" runat="server"></asp:DropDownList>

        <asp:Button ID="PedirButton" runat="server" Text="Pedir" OnClick="PedirButton_Click" />
    </div>
     <asp:Image ID="CalzadoImage" CssClass="img img-thumbnail" runat="server" />

    <asp:GridView class="table table-responsive" runat="server" ID="CarritoGrid" OnRowCommand="CarritoGrid_RowCommand">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
</asp:Content>
