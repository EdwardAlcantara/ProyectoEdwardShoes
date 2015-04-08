using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore
{
    public partial class Mostrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int ID = 0;
            int.TryParse(Request.QueryString["Id"], out ID);

            CalzadosDetalle calzado = new CalzadosDetalle();
            myDataList.DataSource = calzado.CargarTodos(ID);
            myDataList.DataBind();
        }
    }
}