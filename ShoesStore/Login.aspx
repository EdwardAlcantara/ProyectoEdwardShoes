<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoesStore.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="form-horizontal" role="form">
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-2 control-label">Usuario</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="UsuarioTextBox" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-2 control-label">Clave</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="PasswordTextBox" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox">
                            Remember me
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="LoginButton" runat="server" class="btn btn-success" Text="Login" OnClick="LoginButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
