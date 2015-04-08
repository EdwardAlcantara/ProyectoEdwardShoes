using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Size
    {
        public int IdSize { get; set; }
        public double Tamaño { get; set; }
        public bool EsNulo { get; set; }

        public Size()
        {

        }

        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM Size WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
    }
}