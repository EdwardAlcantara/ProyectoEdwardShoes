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
    public partial class rMarca : System.Web.UI.Page
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
                        Session["IdMarca"] = Id;
                        Marca marca = new Marca();
                        marca.Buscar(Id);
                        IdMarcaTextBox.Text = Id.ToString();
                        DescripcionTextBox.Text = marca.Descripcion;
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

        public void LimpiarCampos1()
        {

            DescripcionTextBox.Text = "";
            

        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos1();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            if (Session["IdMarca"] != null)
            {
                marca.IdMarca = Convert.ToInt32(Session["IdMarca"]);
            }
            marca.Descripcion = DescripcionTextBox.Text;
            if (Session["IdMarca"] == null)
            {
                if (marca.Insertar())
                {
                    MensajeLabel.Text = "Insertado!";
                }
            }
            else
            {
                if (marca.Modificar())
                {
                    MensajeLabel.Text = "Modificado!";
                }
            }

            DescripcionTextBox.Text = "";
        }


    }
}