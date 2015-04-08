using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore.Administracion.SeccionTipo
{
    public partial class cTipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Cargar todos los calzados que sean = a nulo
                    TipoGridView.DataSource = Tipo.Listar("IdTipo, Descripcion", "EsNulo = 0", "IdTipo, Descripcion");
                    TipoGridView.DataBind();
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
            TipoGridView.DataSource = Tipo.Listar("IdTipo, Descripcion", "EsNulo = 0 And " + BusquedaPorDropDownList.Text + " like '%" + BusquedaTextBox.Text + "%'", "IdTipo, Descripcion");
            TipoGridView.DataBind();
        }

        protected void TipoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtener el Id en la variable Valor
            int Index = Convert.ToInt32(e.CommandArgument);
            string Valor = TipoGridView.Rows[Index].Cells[2].Text;
            if (e.CommandName == "Delete")
            {
                Tipo tipo = new Tipo();
                tipo.Eliminar(Convert.ToInt32(Valor));
                Response.Redirect("/Administracion/SeccionTipo/cTipo.aspx");
            }
        }
    }
}