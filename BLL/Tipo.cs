using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Tipo
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
        public bool EsNulo { get; set; }

        ConexionDb Conexion = new ConexionDb();

        public Tipo()
        {

        }


        public bool Insertar()
        {
            return Conexion.EjecutarComando("INSERT INTO Tipo(Descripcion)VALUES('" + Descripcion + "')");
        }

        public bool Modificar()
        {
            return Conexion.EjecutarComando("UPDATE Tipo SET Descripcion = '" + Descripcion + "' WHERE IdTipo = " + IdTipo);
        }

        public bool Eliminar(int prmIdTipo)
        {
            return Conexion.EjecutarComando("UPDATE Tipo SET esNulo = 1 WHERE IdTipo = " + prmIdTipo);
        }

        public bool Buscar(int IdTipo)
        {
            SqlDataReader dtr;
            bool Retorno = false;

            dtr = Conexion.getReader("SELECT * FROM Tipo WHERE IdTipo =" + IdTipo);

            while (dtr.Read())
            {
                IdTipo = (Int32)dtr["IdTipo"];
                Descripcion = (String)dtr["Descripcion"];
                EsNulo = (bool)dtr["EsNulo"];
                Retorno = true;
            }

            dtr.Close();
            return Retorno;
        }


        public static object Buscar(string Campos, string Where)
        {
            ConexionDb Conexion = new ConexionDb();
            DataTable Datos = new DataTable();
            return Conexion.getDbValue("Select " + Campos + " from Tipo Where " + Where);
        }

        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM Tipo WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
    }
}