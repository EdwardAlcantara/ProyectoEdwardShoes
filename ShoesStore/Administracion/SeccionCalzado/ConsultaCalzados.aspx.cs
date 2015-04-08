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
    public partial class ConsultaCalzados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Cargar todos los calzados que sean = a nulo
                    CalzadoGridView.DataSource = Calzados.Listar("IdCalzado, m.Descripcion, Modelo", "c.EsNulo = 0 ", "IdCalzado, m.Descripcion, Modelo");
                    CalzadoGridView.DataBind();
                }
                else
                {
                    //Redirecciona al login si no esta activa la session
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        protected void CalzadoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtener el Id en la variable Valor
            int Index = Convert.ToInt32(e.CommandArgument);
            string Valor = CalzadoGridView.Rows[Index].Cells[2].Text;
            if (e.CommandName == "Delete")
            {
                Calzados calzado = new Calzados();
                calzado.Eliminar(Convert.ToInt32(Valor));
                Response.Redirect("/Administracion/SeccionCalzado/ConsultaCalzados.aspx");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            CalzadoGridView.DataSource = Calzados.Listar("IdCalzado, m.Descripcion, Modelo", "c.EsNulo = 0 And " + BusquedaPorDropDownList.Text + " like '%" + BusquedaTextBox.Text + "%'", "IdCalzado, m.Descripcion, Modelo");
            CalzadoGridView.DataBind();
        }
    }
}