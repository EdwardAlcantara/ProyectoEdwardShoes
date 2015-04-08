<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrodCalzados.aspx.cs" Inherits="ShoesStore.Administracion.SeccionCalzado.RegistrodCalzados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registro de Calzados</div>
        <div class="panel-body">

            <div class="form-horizontal col-md-12">

                 <div class="col-md-5">
                    <asp:Label ID="Label2" runat="server" Text="IdCalzadoDetalle"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="IdCalzadoDetalleTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label1" runat="server" Text="IdCalzado"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="IdCalzadoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label4" runat="server" Text="Tipo"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="IdTipoDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="IdTipoDropDownList"
                        ErrorMessage="Tipo es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label3" runat="server" Text="Color"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="IdColorDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="IdColorDropDownList"
                        ErrorMessage="Color es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label10" runat="server" Text="Precio"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="PrecioTextBox" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="PrecioTextBox"
                        ErrorMessage="Precio es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                        ControlToValidate="PrecioTextBox"
                        ErrorMessage="Solo se permite caracteres en el Precio"
                        ForeColor="Red"
                        SetFocusOnError="True"
                        ValidationExpression="^(?:\+|-)?\d+$">*
                    </asp:RegularExpressionValidator>

                </div>
                <div class="col-md-5">
                    <asp:Label ID="Label5" runat="server" Text="Costo"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="CostoTextBox" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="CostoTextBox"
                        ErrorMessage="Costo es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="CostoTextBox"
                        ErrorMessage="Solo se permite caracteres en el Costo"
                        ForeColor="Red"
                        SetFocusOnError="True"
                        ValidationExpression="^(?:\+|-)?\d+$">*
                    </asp:RegularExpressionValidator>

                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label8" runat="server" Text="Size"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="IdSizeDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="IdSizeDropDownList"
                        ErrorMessage="Size es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label6" runat="server" Text="Disponible"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="ExistenciaTextBox" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ExistenciaTextBox"
                        ErrorMessage="Existencia es Necesario"
                        SetFocusOnError="true"
                        ForeColor="Red">*
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ControlToValidate="ExistenciaTextBox"
                        ErrorMessage="Solo se permite numeros en la existencia"
                        ForeColor="Red"
                        SetFocusOnError="True"
                        ValidationExpression="^(?:\+|-)?\d+$">*
                    </asp:RegularExpressionValidator>
                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label7" runat="server" Text="Clasificacion"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="ClasificacionDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>

                </div>

                <div class="col-md-5">
                    <asp:Label ID="Label9" runat="server" Text="Imagen"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:FileUpload ID="CalzadoFileUpload" CssClass="form-control" runat="server" />
                </div>
            </div>

            <div class="col-md-12 text-center">
                <br />
                <br />
                <asp:Button ID="GuardarButton" runat="server" class="btn btn-default" Text="Guardar" OnClick="GuardarButton_Click" />
                                <asp:Button ID="LimpiarButton" runat="server" class="btn btn-default" Text="Limpiar" OnClick="LimpiarButton_Click" />
                <asp:Button ID="DeleteButton" runat="server" class="btn btn-default" Text="Delete"  />
               <asp:Button ID="ConsultaButton" runat="server" class="btn btn-default" Text="Consulta"  />
            </div>

            <div class="col-md-4">
                <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
                <asp:ValidationSummary ID="CursosValidationSummary" ForeColor="Red" runat="server" DisplayMode="List" />
            </div>

        </div>

    </div>

</asp:Content>
