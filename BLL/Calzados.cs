using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Calzados
    {
        public int IdCalzado { get; set; }
        public int IdMarca { get; set; }
        public string Modelo { get; set; }
        public int IdUsuario { get; set; }
        public bool EsNulo { get; set; }

        ConexionDb Conexion = new ConexionDb();

        public Calzados()
        {
        }

        public bool Insertar()
        {
            bool paso = false;
            paso = Conexion.EjecutarComando("INSERT INTO Calzados(IdMarca, Modelo, IdUsuario)"
            + "VALUES('" + IdMarca + "','" + Modelo + "','" + IdUsuario + "')");

            if (paso)
            {
                this.IdCalzado = (int)Conexion.getDbValue("SELECT max (IdCalzado) FROM Calzados");
            }
            return paso;
        }

        public bool Modificar()
        {
            return Conexion.EjecutarComando("UPDATE Calzados SET IdMarca = '" + IdMarca + "', Modelo = '" + Modelo + "',IdUsuario = '" + IdUsuario + "' WHERE IdCalzado = " + IdCalzado);
        }

        public bool Eliminar(int prmIdCalzado)
        {
            return Conexion.EjecutarComando("UPDATE Calzados SET esNulo = 1 WHERE IdCalzado = " + prmIdCalzado);
        }

        public bool Buscar(int IdCalzado)
        {
            SqlDataReader dtr;
            bool Retorno = false;
            dtr = Conexion.getReader("SELECT * FROM Calzados WHERE IdCalzado =" + IdCalzado);
            while (dtr.Read())
            {
                IdCalzado = (Int32)dtr["IdCalzado"];
                IdMarca = (Int32)dtr["IdMarca"];
                Modelo = (String)dtr["Modelo"];
                IdUsuario = (Int32)dtr["IdUsuario"]; 
                EsNulo = (bool)dtr["EsNulo"];
                Retorno = true;
            }

            dtr.Close();
            return Retorno;
        }

        public DataTable CargarTodos()
        {
            return Conexion.getData("SELECT * FROM Calzados WHERE esNulo = 0 ORDER BY IdCalzado DESC ");
        }

         public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM Calzados c INNER JOIN Marca m ON c.IdMarca = m.IdMarca  WHERE " + FiltroWhere + " Order By " + OrderBy);
        }
        
    }
}