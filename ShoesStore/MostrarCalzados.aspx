<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MostrarCalzados.aspx.cs" Inherits="ShoesStore.MostrarCalzados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" TypeName="BLL.CalzadosDetalle" SelectMethod="CargarTodos" runat="server"></asp:ObjectDataSource>

    <div class="col-md-8">
        <asp:DataList runat="server" ID="myDataList" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <hr />
            <div class="col-md-12">
                <div class="col-md-4">
                    <img class="img img-thumbnail" src="/Imagenes/<%# Eval("Imagen")%>" alt="Alternate Text" />
                </div>
                <div class="col-md-8">
                    <div class="col-md-8">
                    <strong>Marca:  <b><%# Eval("Descripcion") %> </b></strong>
                    <br />
                    <strong>Modelo:  <b><%# Eval("Modelo") %> </b></strong>
                    <br />
                    <strong>Color:  <b><%# Eval("Color") %> </b></strong>
                   
                    <br />
                    <a href='/Calzado.aspx?Id=<%# Eval("IdCalzadoDetalle") %>'> Ver  </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    </div>
    <div class="col-md-4">
        <div class="col-md-12">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3771.14167973281!2d-70.17987809999998!3d19.05750739999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8eafcf6d4b049e15%3A0x70683f554d438a54!2sCarretera+Cotu%C3%AD+-+Presa+de+Hatillo%2C+Quitasue%C3%B1o+43000!5e0!3m2!1ses!2sdo!4v1417457685386" width="300" height="300" frameborder="0" style="border:0"></iframe>        </div>

    </div>
    
</asp:Content>
