<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Mostrar.aspx.cs" Inherits="ShoesStore.Mostrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-8">
        <asp:DataList runat="server" ID="myDataList" >
        <ItemTemplate>
            <hr />
            <div class="col-md-12">
                <div class="col-md-4">´
                    <img class="img img-thumbnail" src="/Imagenes/<%# Eval("Imagen")%>" alt="Alternate Text" />
                </div>
                <div class="col-md-8">
                    <strong>Marca:  <b><%# Eval("Descripcion") %> </b></strong>
                    <br />
                    <strong>Modelo:  <b><%# Eval("Modelo") %> </b></strong>
                    <br />
                    <strong>Color:  <b><%# Eval("Color") %> </b></strong>
                    <br />
                    <a href='/Calzado.aspx?Id=<%# Eval("IdCalzadoDetalle") %>'>Ver  </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    </div>
</asp:Content>
