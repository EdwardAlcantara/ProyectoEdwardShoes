<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Calzado.aspx.cs" Inherits="ShoesStore.Calzado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <div class="form-horizontal">
            <div class="col-md-6">
                 <strong><asp:Label ID="Label1" runat="server" Text="Marca"></asp:Label></strong>
            </div>
            <div class="col-md-6">
                <asp:Label ID="MarcaLabel" runat="server" Text=""></asp:Label>
            </div>

            <div class="col-md-6">
                 <strong><asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label></strong>
            </div>
            <div class="col-md-6">
                <asp:Label ID="ModeloLabel" runat="server" Text=""></asp:Label>
            </div>
            
            <br />
            
             <div class="col-md-6">
                 <strong><asp:Label ID="Label3" runat="server" Text="Disponible"></asp:Label></strong>
            </div>
            <div class="col-md-6">
                <asp:Label ID="DisponibleLabel" runat="server" Text=""></asp:Label>
            </div>
            
            <br />

            <div class="col-md-6">
                 <strong><asp:Label ID="Label4" runat="server" Text="Tipo"></asp:Label></strong>
            </div>
            <div class="col-md-6">
                <asp:Label ID="TipoLabel" runat="server" Text=""></asp:Label>
            </div>
            
            <br />

            <div class="col-md-6">
                 <strong><asp:Label ID="Label5" runat="server" Text="Clasificacion"></asp:Label></strong>
            </div>
            <div class="col-md-6">
                <asp:Label ID="ClasificacionLabel" runat="server" Text=""></asp:Label>
            </div>
            
            <br />

            <div class="col-md-6">
                 <strong><asp:Label ID="Label6" runat="server" Text="Precio"></asp:Label></strong>
            </div>
            <div class="col-md-6">
                <asp:Label ID="PrecioLabel" runat="server" Text=""></asp:Label>
            </div>
            
            <br />
            
        </div>

        <div class="row col-md-4 col-md-offset-4">

            <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="CarritoButton" CssClass="btn btn-default" runat="server" Text="Agregar al carrito" OnClick="CarritoButton_Click" />
            <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
        </div>

        
    </div>
    <div class="col-md-6">
        <asp:Image ID="CalzadoImage" CssClass="img img-thumbnail" runat="server" />
    </div>

    <br />
    <br />
    <br />

</asp:Content>
