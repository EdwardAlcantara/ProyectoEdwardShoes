using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ShoesStore
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoGrid.DataSource = CarritoCompra.Listar("IdCarrito, c.IdCalzado as IdCalzadoDetalle ,Imagen, Cantidad, Costo, Precio, co.Descripcion as Color, Total", "EsEntregado = 0", "IdCalzadoDetalle");
            CarritoGrid.DataBind();

            FormaPagoDropDownList.DataSource = FormaPago.Listar("IdFormaPago, NombreForma", "1=1", "IdFormaPago");
            FormaPagoDropDownList.DataValueField = "IdFormaPago";
            FormaPagoDropDownList.DataTextField = "NombreForma";
            FormaPagoDropDownList.DataBind();
        }

        protected void CarritoGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (index == -1)
                {
                    return;
                }
                GridViewRow row = CarritoGrid.Rows[index];
                IdCarritoTextBox.Text = CarritoGrid.Rows[index].Cells[1].Text;
                IdCalzadoTextBox.Text = CarritoGrid.Rows[index].Cells[2].Text;
                CalzadoImage.ImageUrl = "/Imagenes/" + CarritoGrid.Rows[index].Cells[3].Text;
                CantidadTextBox.Text = CarritoGrid.Rows[index].Cells[4].Text;
                TotalTextBox.Text = CarritoGrid.Rows[index].Cells[8].Text;
            }
        }

        protected void PedirButton_Click(object sender, EventArgs e)
        {
            CarritoCompra carrito = new CarritoCompra();

            if (carrito.Eliminar(Convert.ToInt32(IdCarritoTextBox.Text)))
            {
                CalzadosDetalle.ReducirExistencia(Convert.ToInt32(IdCalzadoTextBox.Text), Convert.ToInt32(CantidadTextBox.Text));
                MensajeLabel.Text = "Su Tenis ya esta pedido!";
            }


        }
    }
}