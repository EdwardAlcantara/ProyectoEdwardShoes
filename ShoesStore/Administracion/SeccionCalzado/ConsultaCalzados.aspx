<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConsultaCalzados.aspx.cs" Inherits="ShoesStore.ConsultaCalzados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-12">
        <div class="col-md-2">
            <strong>Buscar Por:</strong>
        </div>
        <div class="col-md-4">
            <asp:DropDownList ID="BusquedaPorDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem Text="IdCalzado"></asp:ListItem>
                <asp:ListItem Text="Descripcion"></asp:ListItem>
                <asp:ListItem Text="Modelo"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="BusquedaTextBox" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>


    <asp:GridView ID="CalzadoGridView" CssClass="table table-striped" runat="server" OnRowCommand="CalzadoGridView_RowCommand">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="IdCalzado" DataNavigateUrlFormatString="/Administracion/SeccionCalzado/RegistroCalzados.aspx?IdCalzado={0}" Text="Modificar" />
            <asp:HyperLinkField DataNavigateUrlFields="IdCalzado" DataNavigateUrlFormatString="/Administracion/SeccionCalzado/RegistrodCalzados.aspx?Id={0}" Text="Agregar Calzado" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
