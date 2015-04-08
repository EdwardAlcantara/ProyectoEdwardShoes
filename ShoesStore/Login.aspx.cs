using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace ShoesStore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (usuario.Autenticar(UsuarioTextBox.Text, PasswordTextBox.Text) != 0)
            {
                Session["Autenticado"] = 1;
                FormsAuthentication.RedirectFromLoginPage(UsuarioTextBox.Text, false);
            } 
        }
    }
}