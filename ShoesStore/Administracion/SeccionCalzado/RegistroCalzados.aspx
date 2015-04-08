<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroCalzados.aspx.cs" Inherits="ShoesStore.RegistroCalzados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="panel panel-default">
        <div class="panel-heading">Registro de Calzados</div>
        <div class="panel-body">

            <div class="form-horizontal col-md-12">
                <div class="col-md-5">
                    <asp:Label ID="Label1" runat="server" Text="IdCalzado"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="IdCalzadoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label2" runat="server" Text="Marca"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="IdMarcaDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="IdMarcaDropDownList"
                        ErrorMessage="Marca es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label3" runat="server" Text="Modelo"></asp:Label>
                </div>
                <div class="col-sm-7">
                    <asp:TextBox ID="ModeloTextBox" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="PrimerNombreRequiredFieldValidator" runat="server"
                        ControlToValidate="ModeloTextBox"
                        ErrorMessage="Modelo es Necesario!"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="Validator" runat="server"
                        ControlToValidate="ModeloTextBox"
                        ErrorMessage="Solo se permite caracteres en el modelo"
                        ForeColor="Red"
                        SetFocusOnError="True"
                        ValidationExpression="^[a-zA-ZñÑ\s]{2,50}">*
                    </asp:RegularExpressionValidator>
                </div>

               

            <div class="col-md-12 text-center">
                <br />
                <br />
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-default" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="LimpiarButton" runat="server" class="btn btn-default" Text="Limpiar" OnClick="LimpiarButton_Click" />
                <asp:Button ID="DeleteButton" runat="server" class="btn btn-default" Text="Delete" />
               <asp:Button ID="ConsultaButton" runat="server" class="btn btn-default" Text="Consulta"  />
            </div>

            <div class="col-md-4">
                <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
                <asp:ValidationSummary ID="CursosValidationSummary" ForeColor="Red" runat="server" DisplayMode="List" />
            </div>

        </div>

    </div>
</asp:Content>
