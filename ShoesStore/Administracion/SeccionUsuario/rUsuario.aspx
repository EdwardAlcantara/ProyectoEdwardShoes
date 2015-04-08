<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rUsuario.aspx.cs" Inherits="ShoesStore.Administracion.Usuario.rUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="center">
        <div class="panel panel-default">
            <div class="panel panel-heading">
                <h5>Registro Usuario</h5>
            </div>
            <div class="panel panel-body">

                <div class="form-group col-md-12">
                    <div class="col-md-4">
                        <strong>IdUsuario</strong>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="IdUsuarioTextBox" class="form-control input-sm" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="col-md-4">
                        <strong>Nombres </strong>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="NombresTextBox" class="form-control input-sm" runat="server"></asp:TextBox>
                        <strong>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombresTextBox" ErrorMessage="Debe llenar el nombre" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </strong>
                    </div>
                </div>


                <div class="col-md-12">

                    <div class="col-md-4">
                        <strong>Apellidos </strong>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="ApellidosTextBox" class="form-control input-sm" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ApellidosTextBox" ErrorMessage="Debe llenar el apellido" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </div>

                </div>

                <div class="col-md-12">
                    <div class="col-md-4">
                        <strong>Alias </strong>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="AliasTextBox" class="form-control input-sm" runat="server" MaxLength="23"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AliasTextBox" ErrorMessage="Debe llenar el alias" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </div>
                </div>

               

                   <div class="form-group col-md-12 row">
                    <%--Clave--%>
                    <div class="col-md-4">
                        <strong>Clave</strong>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="ClaveTextBox" class="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                            ErrorMessage="Clave esta Vacio"
                            ControlToValidate="ClaveTextBox"
                            ForeColor="Red">*
                        </asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group col-md-12 row">
                    <%--Clave--%>
                    <div class="col-md-4">
                        <strong></strong>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="Clave2TextBox" class="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                       

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="Clave esta Vacio"
                            ControlToValidate="Clave2TextBox"
                            ForeColor="Red">*
                        </asp:RequiredFieldValidator>

                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ErrorMessage="Las Contraseñas no concuerdan"
                            ControlToValidate="ClaveTextBox"
                            ControlToCompare="Clave2TextBox">*
                        </asp:CompareValidator>

                    </div>
                </div>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

            </div>
            <div class="panel panel-footer">
                <div class="text-center">
                    <asp:Button ID="GuardarButton" runat="server" class="btn btn-default" Text="Guardar" OnClick="GuardarButton_Click" />
                                    <asp:Button ID="LimpiarButton" runat="server" class="btn btn-default" Text="Limpiar" OnClick="GuardarButton_Click" />
                <asp:Button ID="DeleteButton" runat="server" class="btn btn-default" Text="Delete"  />
               <asp:Button ID="ConsultaButton" runat="server" class="btn btn-default" Text="Consulta" />
                    <br />
                    <asp:Label ID="MensajeLabel" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                </div>

                
            </div>
        </div>
    </div>


</asp:Content>
