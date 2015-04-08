using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Clasificacion
    {
        public int IdClasificacion { get; set; }
        public string Descripcion { get; set; }
        public int TipoClasificacion { get; set; }
        public bool EsNulo { get; set; }

        public Clasificacion()
        {

        }

        public static object Buscar(string Campos, string Where)
        {
            ConexionDb Conexion = new ConexionDb();
            DataTable Datos = new DataTable();
            return Conexion.getDbValue("Select " + Campos + " from Clasificacion Where " + Where);
        }

        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM Clasificacion WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
    }
}