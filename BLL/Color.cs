using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Color
    {
        public int IdColor { get; set; }
        public string Descripcion { get; set; }


        public Color()
        {

        }
        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM Color WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
    }
}