using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class CarritoCompra
    {
        public int IdCarrito { get; set; }
        public int IdCalzado { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public Boolean EsEntregado { get; set; }

        ConexionDb Conexion = new ConexionDb();

        public CarritoCompra()
        {

        }

        public bool Insertar()
        {
            return Conexion.EjecutarComando("INSERT INTO CarritoCompra(IdCalzado, Cantidad, Total)"
            + "VALUES('" + IdCalzado + "','" + Cantidad +"','" + Total +"')");
        }

        public bool Modificar()
        {
            return Conexion.EjecutarComando("UPDATE CarritoCompra SET IdCalzado = '" + IdCalzado + "', Cantidad = '" + Cantidad + ",'Total = '" + Total + "' WHERE IdCarrito = " + IdCarrito);
        }

        public bool Eliminar(int IdCarrito)
        {
            return Conexion.EjecutarComando("UPDATE CarritoCompra SET EsEntregado = 1 WHERE IdCarrito = " + IdCarrito);
        }

        public bool Buscar(int IdFormaPago)
        {
            SqlDataReader dtr;
            bool Retorno = false;

            dtr = Conexion.getReader("SELECT * FROM CarritoCompra WHERE IdCarrito =" + IdCarrito);

            while (dtr.Read())
            {
                IdCarrito = (Int32)dtr["IdCarrito"];
                IdCalzado = (Int32)dtr["IdCalzado"];
                Cantidad = (Int32)dtr["Cantidad"];
                Total = (double)dtr["Total"];
                EsEntregado = (Boolean)dtr["EsEntregado"];
                Retorno = true;
            }

            dtr.Close();
            return Retorno;
        }


        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT DISTINCT " + Campos + " FROM CarritoCompra c INNER JOIN CalzadoDetalle d ON d.IdCalzadoDetalle = c.IdCalzado INNER JOIN Color co ON co.IdColor = d.IdColor INNER JOIN Clasificacion cl ON cl.IdClasificacion = d.IdClasificacion WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
        

    }
}