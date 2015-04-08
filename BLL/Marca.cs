using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public bool EsNulo { get; set; }

        ConexionDb Conexion = new ConexionDb();

        public Marca()
        {

        }

        public bool Insertar()
        {
            return Conexion.EjecutarComando("INSERT INTO Marca(Descripcion)VALUES('" + Descripcion + "')");
        }

        public bool Modificar()
        {
            return Conexion.EjecutarComando("UPDATE Marca SET Descripcion = '" + Descripcion + "' WHERE IdMarca = " + IdMarca);
        }

        public bool Eliminar(int prmIdMarca)
        {
            return Conexion.EjecutarComando("UPDATE Marca SET esNulo = 1 WHERE IdMarca = " + prmIdMarca);
        }

        public bool Buscar(int IdMarca)
        {
            SqlDataReader dtr;
            bool Retorno = false;

            dtr = Conexion.getReader("SELECT * FROM Marca WHERE IdMarca =" + IdMarca);

            while (dtr.Read())
            {
                IdMarca = (Int32)dtr["IdMarca"];
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
            return Conexion.getDbValue("Select "+ Campos +" from Marca Where "+ Where);
        }


        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM Marca WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
    }
}