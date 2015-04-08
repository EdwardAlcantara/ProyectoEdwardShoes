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
    public partial class RegistroCalzados : System.Web.UI.Page
    {
        int Id;
        string imagen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Cargando todas las marcas
                    IdMarcaDropDownList.DataSource = Marca.Listar("IdMarca, Descripcion", "1=1", "IdMarca, Descripcion");
                    IdMarcaDropDownList.DataTextField = "Descripcion";
                    IdMarcaDropDownList.DataValueField = "IdMarca";
                    //Mostrar la consulta
                    IdMarcaDropDownList.DataBind();

                    if (int.TryParse(Request.QueryString["IdCalzado"], out Id))
                    {
                        //Si el valor por QueryString es Entero se lo asigna al Id y Busca el Calzado Llenando los campos
                        Session["IdCalzado"] = Id;
                        Calzados calzado = new Calzados();
                        calzado.Buscar(Id);
                        LlenarCampos(calzado);
                        //imagen = calzado.Imagen;
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
            ModeloTextBox.Text = "";
            IdMarcaDropDownList.SelectedIndex = -1;
        }
        public void LimpiarCampos1()
        {

            ModeloTextBox.Text = "";
        }
       
        public void LlenarClase(Calzados calzado)
        {
            //Asigna el Id al calzado si esta modificando
            if (Session["IdCalzado"] != null)
            {
                calzado.IdCalzado = Convert.ToInt32(Session["IdCalzado"]);
            }
            //Llena los campos
            calzado.IdMarca = Convert.ToInt32(IdMarcaDropDownList.SelectedValue);
            calzado.Modelo = ModeloTextBox.Text;
            calzado.IdUsuario = 1;
        }

        public void LlenarCampos(Calzados calzado)
        {
            IdCalzadoTextBox.Text = Id.ToString();
            IdMarcaDropDownList.SelectedValue = calzado.IdMarca.ToString();
            ModeloTextBox.Text = calzado.Modelo.ToString();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Calzados calzado = new Calzados();
            LlenarClase(calzado);

            if (Session["IdCalzado"] == null)
            {
                calzado.Insertar();
                LimpiarCampos();
                MensajeLabel.Text = "Registrado Con Exito";
                Response.Redirect("/Administracion/SeccionCalzado/RegistrodCalzados.aspx?IdCalzado=" + calzado.IdCalzado);
            }
            else
            {

                calzado.Modificar();

                //Anula la session para no tener el Id Anterior almacenado
                Session["IdCalzado"] = null;
                Response.Redirect("/Administracion/SeccionCalzado/ConsultaCalzados.aspx");
            }
       
        
       }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos1();
        }
    }
}