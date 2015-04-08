using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore.Administracion.Usuario
{
    public partial class rUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    int Id;
                    if (int.TryParse(Request.QueryString["Id"], out Id))
                    {
                        //Si el valor por QueryString es Entero se lo asigna al Id y Busca el Calzado Llenando los campos
                        Session["IdUsuario"] = Id;
                        Usuarios usuario = new Usuarios();
                        usuario.Buscar(Id);
                        IdUsuarioTextBox.Text = usuario.Id.ToString();
                        AliasTextBox.Text = usuario.Alias;
                        NombresTextBox.Text = usuario.Nombres;
                        ApellidosTextBox.Text = usuario.Apellidos;

                    }
                    else
                    {

                    }
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        public void LimpiarCampos()
        {
            NombresTextBox.Text = "";
            ApellidosTextBox.Text = "";
            AliasTextBox.Text = "";
            ClaveTextBox.Text = "";
        }

        public void LimpiarCampos1()
        {


            NombresTextBox.Text = "";
            ApellidosTextBox.Text = "";
            AliasTextBox.Text = "";
            ClaveTextBox.Text = "";

        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos1();
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (Session["IdUsuario"] != null)
            {
                usuario.Id = Convert.ToInt32(Session["IdUsuario"]);
            }

            usuario.Alias = AliasTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.Nombres = NombresTextBox.Text;
            usuario.Apellidos = ApellidosTextBox.Text;
            if (Session["IdUsuario"] == null)
            {
                if (usuario.Insertar())
                {
                    MensajeLabel.Text = "Usuario Guardado Con Exito";
                }

            }
            else
            {
                if (usuario.Modificar())
                {
                    MensajeLabel.Text = "Usuario Modificado Con Exito";
                }
            }
            LimpiarCampos();
        }
    }
}