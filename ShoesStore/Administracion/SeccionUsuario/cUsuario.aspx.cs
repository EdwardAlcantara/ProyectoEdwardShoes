using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore.Administracion.SeccionUsuario
{
    public partial class cUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Cargar todos los calzados que sean = a nulo
                    UsuarioGridView.DataSource = Usuarios.Listar("Id, Alias, Nombres, Apellidos", "EsNulo = 0");
                    UsuarioGridView.DataBind();
                }
                else
                {
                    //Redirecciona al login si no esta activa la session
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            UsuarioGridView.DataSource = Usuarios.Listar("Id, Alias, Nombres, Apellidos", "EsNulo = 0 And " + BusquedaPorDropDownList.Text + " like '%" + BusquedaTextBox.Text + "%'");
            UsuarioGridView.DataBind();
        }

        protected void UsuarioGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtener el Id en la variable Valor
            int Index = Convert.ToInt32(e.CommandArgument);
            string Valor = UsuarioGridView.Rows[Index].Cells[2].Text;
            if (e.CommandName == "Delete")
            {
                Usuarios usuario = new Usuarios();
                usuario.Eliminar(Convert.ToInt32(Valor));
                Response.Redirect("/Administracion/SeccionUsuario/cUsuario.aspx");
            }
        }
    }
}