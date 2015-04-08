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
    public partial class rTipo : System.Web.UI.Page
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
                        Session["IdTipo"] = Id;
                        Tipo tipo = new Tipo();
                        tipo.Buscar(Id);
                        IdTipoTextBox.Text = Id.ToString();
                        DescripcionTextBox.Text = tipo.Descripcion;
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
            Tipo tipo = new Tipo();
            if (Session["IdTipo"] != null)
            {
                tipo.IdTipo = Convert.ToInt32(Session["IdTipo"]);
            }
            tipo.Descripcion = DescripcionTextBox.Text;


            if (Session["IdTipo"] == null)
            {
                if (tipo.Insertar())
                {
                    MensajeLabel.Text = "Insertado!";
                }
            }
            else
            {
                if (tipo.Modificar())
                {
                    MensajeLabel.Text = "Modificado!";
                }
            }
            
               
            

            DescripcionTextBox.Text = "";
        }
    }
}