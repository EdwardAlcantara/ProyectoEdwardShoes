using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore.Administracion.SeccionCalzado
{
    public partial class RegistrodCalzados : System.Web.UI.Page
    {   
        int Id;
        string Imagen;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {

                    IdTipoDropDownList.DataSource = Tipo.Listar("IdTipo, Descripcion", "1=1", "IdTipo, Descripcion");
                    IdTipoDropDownList.DataTextField = "Descripcion";
                    IdTipoDropDownList.DataValueField = "IdTipo";
                    IdTipoDropDownList.DataBind();

                    ClasificacionDropDownList.DataSource = Clasificacion.Listar("IdClasificacion, Descripcion", "1=1", "IdClasificacion, Descripcion");
                    ClasificacionDropDownList.DataTextField = "Descripcion";
                    ClasificacionDropDownList.DataValueField = "IdClasificacion";
                    ClasificacionDropDownList.DataBind();

                    IdSizeDropDownList.DataSource = Size.Listar("IdSize, Tamaño", "1=1", "IdSize, Tamaño");
                    IdSizeDropDownList.DataTextField = "Tamaño";
                    IdSizeDropDownList.DataValueField = "IdSize";
                    IdSizeDropDownList.DataBind();

                    IdColorDropDownList.DataSource = Color.Listar("IdColor, Descripcion", "1=1", "IdColor, Descripcion");
                    IdColorDropDownList.DataTextField = "Descripcion";
                    IdColorDropDownList.DataValueField = "IdColor";
                    IdColorDropDownList.DataBind();


                    if (int.TryParse(Request.QueryString["IdCalzado"], out Id))
                    {
                        //Si el valor por QueryString es Entero se lo asigna al Id y Busca el Calzado Llenando los campos
                        Session["IdCalzado"] = Id;
                        CalzadosDetalle dCalzado = new CalzadosDetalle();
                        dCalzado.Buscar(Id);
                        LlenaCampos(dCalzado);

                       // LlenaCampos(calzado);
                        Imagen = dCalzado.Imagen;
                    }
                    if (int.TryParse(Request.QueryString["Id"], out Id))
                    {
                        //Si el valor por QueryString es Entero se lo asigna al Id y Busca el Calzado Llenando los campos
                        Session["Id"] = Id;
                        IdCalzadoTextBox.Text = Id.ToString();
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

        public void LlenaCampos(CalzadosDetalle calzado)
        {
            IdTipoDropDownList.SelectedValue = calzado.IdTipo.ToString();
            IdColorDropDownList.SelectedValue = calzado.IdColor.ToString();
            IdSizeDropDownList.SelectedValue = calzado.IdSize.ToString();
            ExistenciaTextBox.Text = calzado.Existencia.ToString();
            ClasificacionDropDownList.SelectedValue = calzado.IdClasificacion.ToString();
            PrecioTextBox.Text = calzado.Precio.ToString();
            CostoTextBox.Text = calzado.Costo.ToString();
            IdCalzadoTextBox.Text = calzado.IdCalzado.ToString();
            IdCalzadoDetalleTextBox.Text = Id.ToString();

        }
        public void LimpiarCampos1()
        {

            PrecioTextBox.Text = "";
            CostoTextBox.Text = "";
            IdColorDropDownList.Items.Clear();
            IdCalzadoDetalleTextBox.Text = "";
            IdCalzadoTextBox.Text = "";
            ExistenciaTextBox.Text = "";

        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos1();
        }

        public void LlenaClase(CalzadosDetalle calzado)
        {
            if (Session["IdCalzado"] != null)
            {
                calzado.IdCalzadoDetalle = Convert.ToInt32(IdCalzadoDetalleTextBox.Text);
            }
            calzado.IdCalzado = Convert.ToInt32(IdCalzadoTextBox.Text);
            calzado.IdTipo = Convert.ToInt32(IdTipoDropDownList.SelectedValue);
            calzado.IdColor = Convert.ToInt32(IdColorDropDownList.SelectedValue);    
            calzado.IdSize = Convert.ToInt32(IdSizeDropDownList.SelectedValue);
            calzado.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            calzado.IdClasificacion = Convert.ToInt32(ClasificacionDropDownList.SelectedValue);
            calzado.Precio = Convert.ToDouble(PrecioTextBox.Text);
            calzado.Costo = Convert.ToDouble(CostoTextBox.Text);

            if (Session["IdCalzado"] != null)
            {
                //Si tiene Imagen el FileUpload
                if (CalzadoFileUpload.HasFile)
                {
                    calzado.Imagen = CalzadoFileUpload.FileName;
                }
                else
                {
                    calzado.Imagen = Imagen;
                }

            }
            else
            {
                calzado.Imagen = CalzadoFileUpload.FileName;
            }
        }

        public void CargarArchivo()
        {
            if (IsPostBack)
            {
                string extensionArchivo;
                Boolean fileOK = false;
                //Rota donde se almacenan las imagenes
                String path = Server.MapPath("/Imagenes/");
                if (CalzadoFileUpload.HasFile)
                {
                    //Verifica de que el archivo sea una imagen antes de subirlo
                    extensionArchivo = System.IO.Path.GetExtension(CalzadoFileUpload.FileName).ToLower();
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (extensionArchivo == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                //Si es valido sube la imagen
                if (fileOK)
                {
                    try
                    {
                        CalzadoFileUpload.PostedFile.SaveAs(Server.MapPath("/Imagenes/"
                            + CalzadoFileUpload.FileName));
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

        }

        public void LimpiarCampos()
        {
            ExistenciaTextBox.Text = "";
            IdColorDropDownList.SelectedIndex = -1;
            IdSizeDropDownList.SelectedIndex = -1;
            IdTipoDropDownList.SelectedIndex = -1;
            ClasificacionDropDownList.SelectedIndex = -1;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            CalzadosDetalle calzado = new CalzadosDetalle();
            LlenaClase(calzado);

            if (Session["IdCalzado"] == null)
            {
                //Guardar Calzado
                if (CalzadoFileUpload.HasFile)
                {
                    calzado.Insertar();
                    CargarArchivo();
                    LimpiarCampos();
                    MensajeLabel.Text = "Registrado Con Exito";
                }
                else
                {

                }

            }
            else
            {
                //Modificar calzado
                if (CalzadoFileUpload.HasFile)
                {
                    calzado.Modificar();
                    CargarArchivo();
                }
                else
                {
                    calzado.Modificar();
                }
                //Anula la session para no tener el Id Anterior almacenado
                Session["IdCalzado"] = null;
            }

        }
    }
}