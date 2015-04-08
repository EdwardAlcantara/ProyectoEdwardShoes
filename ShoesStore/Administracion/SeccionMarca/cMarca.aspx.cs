using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore.Administracion.SeccionMarca
{
    public partial class cMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Cargar todos los calzados que sean = a nulo
                    MarcaGridView.DataSource = Marca.Listar("IdMarca, Descripcion", "EsNulo = 0", "IdMarca, Descripcion");
                    MarcaGridView.DataBind();
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
            MarcaGridView.DataSource = Marca.Listar("IdMarca, Descripcion", "EsNulo = 0 And " + BusquedaPorDropDownList.Text + " like '%" + BusquedaTextBox.Text + "%'", "IdMarca, Descripcion");
            MarcaGridView.DataBind();
        }

        protected void MarcaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtener el Id en la variable Valor
            int Index = Convert.ToInt32(e.CommandArgument);
            string Valor = MarcaGridView.Rows[Index].Cells[2].Text;
            if (e.CommandName == "Delete")
            {
                Marca marca = new Marca();
                marca.Eliminar(Convert.ToInt32(Valor));
                Response.Redirect("/Administracion/SeccionMarca/cMarca.aspx");
            }
        }
    }
}