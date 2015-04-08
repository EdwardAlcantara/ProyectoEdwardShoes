<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cUsuario.aspx.cs" Inherits="ShoesStore.Administracion.SeccionUsuario.cUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-2">
            <strong>Buscar Por:</strong>
        </div>
        <div class="col-md-4">
            <asp:DropDownList ID="BusquedaPorDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem Text="Id"></asp:ListItem>
                <asp:ListItem Text="Alias"></asp:ListItem>
                <asp:ListItem Text="Nombres"></asp:ListItem>
                <asp:ListItem Text="Apellidos"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="BusquedaTextBox" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BuscarButton_Click"  />
        </div>
    </div>


    <asp:GridView ID="UsuarioGridView" CssClass="table table-striped" runat="server" OnRowCommand="UsuarioGridView_RowCommand" >
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/Administracion/SeccionUsuario/rUsuario.aspx?Id={0}" Text="Modificar" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
