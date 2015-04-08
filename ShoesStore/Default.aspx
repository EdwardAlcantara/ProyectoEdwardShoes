<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoesStore.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="carousel-example-generic" style="height: 300px; margin: 0 auto" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            <li data-target="#carousel-example-generic" data-slide-to="3"></li>
            <li data-target="#carousel-example-generic" data-slide-to="4"></li>
        </ol>

        <!-- Wrapper for slides -->
        <%-- Desde aqui enpienza el area de los Slide--%>
        <div class="carousel-inner" style="height: 300px; margin: 0 auto" role="listbox">
            <div class="item active">
                <img src="/Imagenes/Slide2.png" alt="...">
                <div class="carousel-caption">
                    ...
                </div>
            </div>
            <%--Slide 2--%>

            <div class="item">
                <img src="/Imagenes/collage.png" alt="...">
                <div class="carousel-caption">
                    ...
                </div>
            </div>

            <%--tercer Slip--%>
            ...<div class="item">
                <img src="/Imagenes/RETRO.jpeg" alt="...">
                <div class="carousel-caption">
                    ...
                </div>
            </div>
            ...
           
            ...<div class="item">
                <img src="/Imagenes/lacoste.jpg" alt="...">
                <div class="carousel-caption">
                    ...
                </div>
            </div>
            ...
           
        </div>

         <!-- Controls -->
    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
    </div>






   


</asp:Content>
