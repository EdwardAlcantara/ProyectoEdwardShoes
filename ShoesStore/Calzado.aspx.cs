using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore
{
    public partial class Calzado : System.Web.UI.Page
    {
        string IdCalzado;
        double Precio;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdCalzado = Request.QueryString["Id"];
            Calzados calzado = new Calzados();
            
            CalzadosDetalle dCalzado = new CalzadosDetalle();
            dCalzado.Buscar(Convert.ToInt32(IdCalzado));

            Precio = dCalzado.Precio;

            calzado.Buscar(dCalzado.IdCalzado);
            MarcaLabel.Text = Marca.Buscar("Descripcion", "IdMarca =" + calzado.IdMarca).ToString();
            ModeloLabel.Text = calzado.Modelo;

            DisponibleLabel.Text = dCalzado.Existencia.ToString();
            TipoLabel.Text = Tipo.Buscar("Descripcion", "IdTipo =" +dCalzado.IdTipo).ToString();
            ClasificacionLabel.Text = Clasificacion.Buscar("Descripcion", "IdClasificacion = " + dCalzado.IdClasificacion).ToString();
            CalzadoImage.ImageUrl = "/Imagenes/" + dCalzado.Imagen;
            PrecioLabel.Text =dCalzado.Precio.ToString();
        }

        protected void CarritoButton_Click(object sender, EventArgs e)
        {
            CarritoCompra carrito = new CarritoCompra();
            carrito.IdCalzado = Convert.ToInt32( IdCalzado.ToString());
            carrito.Cantidad = Convert.ToInt32( CantidadTextBox.Text);
            carrito.Total = carrito.Cantidad * Precio;
            carrito.Insertar();
            MensajeLabel.Text = "Agregado al Carrito!";
        }
    }
}