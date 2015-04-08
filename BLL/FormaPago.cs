using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class FormaPago
    {
        public int IdFormaPago { get; set; }
        public string NombreForma { get; set; }
        public string Observacion { get; set; }

        ConexionDb Conexion = new ConexionDb();

        public FormaPago()
        {
        }


        public bool Insertar()
        {
            return Conexion.EjecutarComando("INSERT INTO FormaPago(NombreForma, Observacion)"
            + "VALUES('" + NombreForma + "','" + Observacion +"')");
        }

        public bool Modificar()
        {
            return Conexion.EjecutarComando("UPDATE FormaPago SET NombreForma = '" + NombreForma + "', Observacion = '" + Observacion + "' WHERE IdFormaPago = " + IdFormaPago);
        }

        public bool Eliminar(int prmIdFormaPago)
        {
            return Conexion.EjecutarComando("DELETE FormaPago WHERE IdFormaPago = " + prmIdFormaPago);
        }

        public bool Buscar(int IdFormaPago)
        {
            SqlDataReader dtr;
            bool Retorno = false;

            dtr = Conexion.getReader("SELECT * FROM FormaPago WHERE IdFormaPago =" + IdFormaPago);

            while (dtr.Read())
            {
                IdFormaPago = (Int32)dtr["IdFormaPago"];
                NombreForma = (String)dtr["NombreForma"];
                Observacion = (String)dtr["Observacion"];
                Retorno = true;
            }

            dtr.Close();
            return Retorno;
        }

        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM FormaPago WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
        

    }
}