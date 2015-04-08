<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rTipo.aspx.cs" Inherits="ShoesStore.Administracion.SeccionTipo.rTipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="center">
        <div class="panel panel-default">
            <div class="panel panel-heading">
                <h5>Registro Tipo</h5>
            </div>
            <div class="panel panel-body">

                <div class="form-group col-md-12">
                    <div class="col-md-4">
                       <asp:Label ID="Label1" runat="server" Text="IdTipo"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="IdTipoTextBox" class="form-control input-sm" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="col-md-4">
                        <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="DescripcionTextBox" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Debe llenar el tipo" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Solo debe introducir caracteres" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[a-zA-ZñÑ\s]{2,50}">*</asp:RegularExpressionValidator>
            </div>
            <div class="panel panel-footer">
                <div class="text-center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    <asp:Button ID="GuardarButton" runat="server" class="btn btn-default" Text="Guardar" OnClick="GuardarButton_Click" />
                                    <asp:Button ID="LimpiarButton" runat="server" class="btn btn-default" Text="Limpiar" OnClick="GuardarButton_Click" />
                <asp:Button ID="DeleteButton" runat="server" class="btn btn-default" Text="Delete"  />
               <asp:Button ID="ConsultaButton" runat="server" class="btn btn-default" Text="Consulta"  />
                    <br />
                    <asp:Label ID="MensajeLabel" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                </div>

                
            </div>
        </div>
    </div>

</asp:Content>
